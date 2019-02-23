using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/ToggleAttack")]
public class ToggleAttack:Attack
{
    public Attack baseAttack;

    public override void UseAbility()
    {
        Player player = FindObjectOfType<Player>();
        baseAttack.caster = player;
        if (!player.GetComponent<PlayerStats>().LoseMana(cost))
            player.ability = baseAttack;
        base.UseAbility();
        player.ability = baseAttack;
    }

    public override void OnClick()
    {
        Player player = FindObjectOfType<Player>();
        caster = player;
        player.ability = this;
    }
}
