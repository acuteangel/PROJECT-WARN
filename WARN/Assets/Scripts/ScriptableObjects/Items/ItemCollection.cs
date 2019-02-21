using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectable/ItemCollection")]
public class ItemCollection : ScriptableObject
{
    public Collectable[] collectables = new Collectable[5];
}
