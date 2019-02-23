using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int currentHealth;
    public int currentMana;
    
    public Stat damage;
    public Stat armor;
    public Stat maxHealth;
    public Stat maxMana;

    public List<TimedBuff> buffs = new List<TimedBuff>();

    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
        currentMana = maxMana.GetValue();
    }

    public virtual void AddBuff(Buff buff)
    {
        armor.AddModifier(buff.armorModifier);
        damage.AddModifier(buff.damageModifier);
        maxHealth.AddModifier(buff.healthModifier);
        maxMana.AddModifier(buff.manaModifier);
        CompareHPMP();
        TimedBuff newBuff = new TimedBuff();
        newBuff.duration = buff.duration;
        newBuff.buff = buff;
        buffs.Add(newBuff);
    }

    public void BuffTimer()
    {
        List<TimedBuff> copy = new List<TimedBuff>();
        foreach(TimedBuff buff in buffs)
        {
            buff.duration -= 1;
            if (buff.duration <= 0)
            {
                RemoveBuff(buff.buff);                
            } else
            {
                copy.Add(buff);
            }
        }
        buffs = copy;
    }

    protected virtual void RemoveBuff(Buff buff)
    {
        armor.RemoveModifier(buff.armorModifier);
        damage.RemoveModifier(buff.damageModifier);
        maxHealth.RemoveModifier(buff.healthModifier);
        maxMana.RemoveModifier(buff.manaModifier);
        CompareHPMP();
    }

    public void RemoveAllBuffs()
    {
        foreach (TimedBuff buff in buffs)
        {
            RemoveBuff(buff.buff);
        }
        buffs = new List<TimedBuff>();
    }

    protected virtual void CompareHPMP()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
        currentMana = Mathf.Clamp(currentMana, 0, maxMana.GetValue());
    }

    public void LoseHealth(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage!");

        GetComponent<MovingObject>().LoseHealth();
    }

    public bool LoseMana(int cost)
    {
        if (currentMana >= cost)
        {
            currentMana -= cost;
            CanvasListener.instance.UpdateManaBar();
            return true;
        }
        return false;
    }

    public void ChangeStat(int stat, int amt, bool percent)
    { 
        switch (stat)
        {
            case 0:
                if (percent)
                {
                    amt = maxHealth.GetValue() * amt / 100;
                }
                if (amt < 0)
                {
                    LoseHealth(-amt);
                } else
                {
                    currentHealth += amt;
                    CompareHPMP();
                }
                CanvasListener.instance.UpdateHealthBar();
                break;
            case 1:
                if (percent)
                {
                    amt = maxMana.GetValue() * amt / 100;
                }
                currentMana += amt;
                CompareHPMP();
                CanvasListener.instance.UpdateManaBar();
                break;
        }
    }
}
