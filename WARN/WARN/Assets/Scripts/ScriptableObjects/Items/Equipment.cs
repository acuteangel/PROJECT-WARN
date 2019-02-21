using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectable/Equipment")]
public class Equipment : Collectable
{
    public int armorModifier;
    public int damageModifier;
    public int healthModifier;
    public int manaModifier;

    public EquipmentSlot slot;

    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot { Head, PrimaryWeapon, SecondaryWeapon, Ring, Necklace, Drop }