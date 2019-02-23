using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
 
public class CanvasListener : MonoBehaviour
{
    #region singleton
    public static CanvasListener instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    public GameObject pauseMenu;

    public GameObject menuPanel;

    public GameObject movesMenu;

    public bool subMenu = false;

    public GameObject itemsMenu;
    
    public Button [] buttons;
    
    public Slider healthBar;
    public Slider manaBar;
    public Text HP;
    public Text MP;
    public Text armor;
    public Text damage;
    public Text level;
    public Text currency;

    [HideInInspector]public Player player;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Cancel")) {
            if (GameManager.instance.playerTargeting)
            {                
                GameManager.instance.playerTargeting = false;
                TargetingSystem.instance.ExitTargeting();
                movesMenu.SetActive(true);
                subMenu = true;
                Pause();
                return;
            }
            if (subMenu)
            {
                menuPanel.SetActive(true);
                movesMenu.SetActive(false);
                itemsMenu.SetActive(false);
                subMenu = false;
                FindObjectOfType<EventSystem>().SetSelectedGameObject(menuPanel.GetComponentInChildren<Button>().gameObject);
                return;
            }

            if (!GameManager.instance.isPaused) 
                Pause();
            else
                unPause();
        };
    
        

    }


    public void Pause()
    {
        GameManager.instance.isPaused = true;
        pauseMenu.SetActive(true);
        FindObjectOfType<EventSystem>().SetSelectedGameObject(menuPanel.GetComponentInChildren<Button>().gameObject);
        // Time.timeScale = 0f;

    }


    public void unPause()
    {
        GameManager.instance.isPaused = false;
        pauseMenu.SetActive(false);
        // Time.timeScale = 1f;
    }

    public void OpenMovesMenu()
    {
        FindObjectOfType<EventSystem>().SetSelectedGameObject(movesMenu.GetComponentInChildren<Button>().gameObject);
        subMenu = true;
    }

    public void UpdateHealthBar()
    {
        healthBar.value = player.stats.currentHealth;
        HP.text = player.stats.currentHealth + " / " + player.stats.maxHealth.GetValue();
    }

    public void UpdateManaBar()
    {
        manaBar.value = player.stats.currentMana;
        MP.text = player.stats.currentMana + " / " + player.stats.maxMana.GetValue();
    }
}

