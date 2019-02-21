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

    public GameObject movesMenu;

    public bool subMenu = false;

    public GameObject itemsMenu;
    
    public Button [] buttons;
    
    public Slider healthBar;

    private Player player;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    protected void OnEnable()
    {
        GameManager.OnHealthChange += updateHealthBar;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
        // Time.timeScale = 0f;
        
    }


    public void unPause()
    {
        GameManager.instance.isPaused = false;
        pauseMenu.SetActive(false);
        // Time.timeScale = 1f;
    }

    

    public void updateHealthBar()
    {
        healthBar.value = player.stats.currentHealth;
    }
}

