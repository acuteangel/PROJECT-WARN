using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Currency currency;

    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            maxHealth.AddModifier(newItem.healthModifier);
            maxMana.AddModifier(newItem.manaModifier);
            CompareHPMP();
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            maxHealth.RemoveModifier(newItem.healthModifier);
            maxMana.RemoveModifier(newItem.manaModifier);
            CompareHPMP();
        }
        UpdateStatsUI();
    }

    public override void AddBuff(Buff buff)
    {
        base.AddBuff(buff);
        UpdateStatsUI();
    }

    protected override void RemoveBuff(Buff buff)
    {
        base.RemoveBuff(buff);
        UpdateStatsUI();
    }

    protected override void CompareHPMP()
    {
        base.CompareHPMP();
        CanvasListener.instance.UpdateHealthBar();
        CanvasListener.instance.UpdateManaBar();
    }   

    private void UpdateStatsUI()
    {
        CanvasListener.instance.armor.text = armor.GetValue().ToString();
        CanvasListener.instance.damage.text = damage.GetValue().ToString();        
    }
}
