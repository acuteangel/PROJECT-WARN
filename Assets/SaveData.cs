using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    #region singleton
    public static SaveData instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    #endregion
    public CharacterChoice[] characterChoices;

    private PlayerStats stats;
    private CharacterChoice choice;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();

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
        PlayerStats playerStats = FindObjectOfType<Player>().GetComponent<PlayerStats>();        
        playerStats.RemoveAllBuffs();
        stats.currency = playerStats.currency;
        stats.damage = playerStats.damage;
        stats.armor = playerStats.armor;
        stats.maxHealth = playerStats.maxHealth;
        stats.currentHealth = playerStats.currentHealth;
        stats.maxMana = playerStats.maxMana;
        stats.currentMana = playerStats.currentMana;
    }

    public void LoadCharacter()
    {
        Debug.Log("hi");
        GameObject player = FindObjectOfType<Player>().gameObject;
        PlayerStats characterStats = player.GetComponent<PlayerStats>();
        characterStats.currency = stats.currency;
        characterStats.damage = stats.damage;
        characterStats.armor = stats.armor;
        characterStats.maxHealth = stats.maxHealth;
        characterStats.currentHealth = stats.currentHealth;
        characterStats.maxMana = stats.maxMana;
        characterStats.currentMana = stats.currentMana;
        FindObjectOfType<CameraControl>().GetComponent<CameraControl>().player = player;
    }

}
