using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject charactersPanel;
    public GameObject mainPanel;

    // public GameObject characterList;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Awake()
    {
        OnMouseEnter();

    }

    private void Start()
    {
        charactersPanel.SetActive(false);
        // characterList.SetActive(false);
        mainPanel.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && charactersPanel == true)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    public void CharSelect()
    {
        mainPanel.SetActive(false);
        charactersPanel.SetActive(true);
        // characterList.SetActive(true);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}
