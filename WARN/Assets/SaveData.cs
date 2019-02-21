using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    #region singleton
    public static SaveData instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public CharacterChoice[] characterChoices;

    private PlayerStats stats;
    private CharacterChoice choice;

    // Start is called before the first frame update
    void Start()
    {
        int index = PlayerPrefs.GetInt("CharacterSelected");
        choice = characterChoices[index];
        ItemDrop primary = Instantiate(choice.equip, new Vector3(1, 0, 0), new Quaternion()).GetComponent<ItemDrop>();
        primary.collectable = choice.primaryWeapon;
        ItemDrop secondary = Instantiate(choice.equip, new Vector3(0, 1, 0), new Quaternion()).GetComponent<ItemDrop>();
        secondary.collectable = choice.secondaryWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveCharacter()
    {
        stats = FindObjectOfType<Player>().GetComponent<PlayerStats>();
        stats.RemoveAllBuffs();
    }

    public void LoadCharacter()
    {
        Debug.Log("hi");
        GameObject player = FindObjectOfType<Player>().gameObject;
        CharacterStats characterStats = player.GetComponent<CharacterStats>();
        characterStats = stats;
        FindObjectOfType<CameraControl>().GetComponent<CameraControl>().player = player;
    }

}
