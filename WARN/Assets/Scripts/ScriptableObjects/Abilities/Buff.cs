using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ability/Buff")]
public class Buff : Ability
{
    public float duration;
    public int armorModifier;
    public int damageModifier;
    public int healthModifier;
    public int manaModifier;

    public override void OnClick()
    {
        target = FindObjectOfType<Player>();
        UseAbility();
        GameManager.instance.playersTurn = false;
    }

    public override void UseAbility()
    {
        CharacterStats stats = target.GetComponent<CharacterStats>();
        stats.AddBuff(this);
        base.UseAbility();
    }
}
