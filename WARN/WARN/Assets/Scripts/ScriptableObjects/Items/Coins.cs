using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectable/Coins")]
public class Coins : Collectable
{
    public int amount;

    public override void Use()
    {
        base.Use();
        GameObject player = FindObjectOfType<PlayerStats>().gameObject;
        player.GetComponent<PlayerStats>().currency.AddCurrency(amount);
    }
}