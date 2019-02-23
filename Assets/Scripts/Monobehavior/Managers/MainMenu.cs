using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject charactersPanel;
    public Transform characterBox;
    public GameObject mainPanel;
    public GameObject characterList;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


   

   void Start()
    {
        OnMouseEnter();
        charactersPanel.SetActive(false);
        characterList.SetActive(false);
        mainPanel.SetActive(true);

        
    }


    void Update()
    {
        if (Input.GetButtonDown("Cancel") && charactersPanel == true)
        {
            charactersPanel.SetActive(false);
            mainPanel.SetActive(true);
            characterList.SetActive(false);
            FindObjectOfType<EventSystem>().SetSelectedGameObject(mainPanel.GetComponentInChildren<Button>().gameObject);
        }

    }

    public void characterTransform()
    {
        characterList.transform.parent = characterBox;
    }


    public void CharSelect()
    {
        mainPanel.SetActive(false);
        charactersPanel.SetActive(true);
        characterTransform();
        characterList.SetActive(true);

        
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
