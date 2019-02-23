using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCompare : MonoBehaviour
{
    private Equipment equip;

    private void OnTriggerStay2D(Collider2D other)
    {
        equip = (Equipment)GetComponentInParent<ItemDrop>().collectable;
        //Debug.Log();
        //Debug.Log(EquipmentManager.instance.equipment[(int)equip.slot]);
    }
}