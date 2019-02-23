using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Collectable collectable;    

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = collectable.sprite;        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectable.Use();
            if (EquipmentManager.instance.equipment[(int)EquipmentSlot.Drop] != null)
            {
                collectable = EquipmentManager.instance.equipment[(int)EquipmentSlot.Drop];
                spriteRenderer.sprite = collectable.sprite;
                EquipmentManager.instance.equipment[(int)EquipmentSlot.Drop] = null;
            } else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
