using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Attack")]
public class Attack:Ability
{
    public int damage = 1;
    public int range = 1;

    public override void UseAbility()
    {
        base.UseAbility();
        target.stats.LoseHealth(damage + caster.stats.damage.GetValue());
    }

    public override void OnClick()
    {
        throw new System.NotImplementedException();
    }
}
