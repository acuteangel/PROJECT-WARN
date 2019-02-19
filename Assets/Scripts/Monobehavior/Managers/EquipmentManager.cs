using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Equipment[] equipment; //{ get; private set; }    
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public ItemCollection[] itemCollections = new ItemCollection[6];
    public Image[] images = new Image[5];

    private ItemDropReaction reaction;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        equipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.slot;

        Equipment oldItem = null;        
        if (equipment[slotIndex] != null)
        {            
            oldItem = equipment[slotIndex];
            equipment[equipment.Length - 1] = oldItem;
        }

        if (onEquipmentChanged != null)
        {            
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        equipment[slotIndex] = newItem;
        images[slotIndex].sprite = newItem.sprite;
    }
}
