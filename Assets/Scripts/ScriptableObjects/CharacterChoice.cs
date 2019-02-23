using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "CharacterChoice")]
public class CharacterChoice: ScriptableObject
{
    public GameObject characterPrefab;
    public new string name;
    public Ability[] abilities = new Ability[4];
    public Equipment primaryWeapon;
    public Equipment secondaryWeapon;
    public ItemCollection[] itemSet = new ItemCollection[6];
    public GameObject equip;
}
