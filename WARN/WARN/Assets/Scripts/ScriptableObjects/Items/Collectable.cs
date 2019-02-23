using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectable/Collectable")]
public class Collectable : ScriptableObject
{
    public Sprite sprite;
    public string aName = "Item name";

    public void Initialize(GameObject obj) { }
    public virtual void Use()
    {
        Debug.Log("Item get");
    }
}