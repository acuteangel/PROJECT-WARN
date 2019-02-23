using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Reaction/ItemDrop")]
public class ItemDropReaction : Reaction
{
    public string aName;
    public GameObject prefab;
    public ItemCollection [] collections;

    private Collectable collectable;

    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction(Interactable interactable)
    {
        int index = Random.Range(0, collections.Length - 14);        
        if (index < 6)
            switch (PlayerPrefs.GetInt("CharacterSelected"))
            {
                case 0:
                case 1:
                    index += 15;                    
                    break;
                case 4:
                case 5:
                    index += 21;
                    break;
            }
        ItemCollection collection = collections[index];
        int tier = Mathf.FloorToInt(GameManager.instance.level / 5);
        collectable = collection.collectables[tier];
        ItemDrop item = prefab.GetComponent<ItemDrop>();
        item.collectable = collectable;
        Instantiate(prefab, interactable.transform.position, new Quaternion());
    }

    protected override void ImmediateReaction(MovingObject interactable)
    {
        ItemCollection collection = collections[Random.Range(0, collections.Length - 1)];
        int tier = Mathf.FloorToInt(GameManager.instance.level / 5);
        collectable = collection.collectables[tier];
        ItemDrop item = prefab.GetComponent<ItemDrop>();
        item.collectable = collectable;
        Instantiate(prefab, interactable.transform.position, new Quaternion());
    }
}
