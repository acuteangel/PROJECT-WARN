using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class MoveList : MonoBehaviour
{

    public Ability[] moveSet;

    public GameObject prefabButton;

    private RectTransform ParentPanel;

    private TMP_Text TextComponent;

    public GameObject firstButton;

    void Start()
    {
    
        ParentPanel = gameObject.GetComponent<RectTransform>();
        SaveData data = FindObjectOfType<SaveData>();
        moveSet = data.characterChoices[PlayerPrefs.GetInt("CharacterSelected")].abilities;
        
        foreach (Ability a in moveSet)
        {
            GameObject goButton;
            if (a == moveSet[0])
            {
                goButton = firstButton;
            } else {
                goButton = Instantiate(prefabButton);
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);                
            }
            goButton.name = "Button " + a;
            TextComponent = goButton.GetComponentInChildren<TextMeshProUGUI>();
            TextComponent.text = (a.aName);
            Button button = goButton.GetComponent<Button>();
            button.onClick.AddListener(delegate { UseButton(a); });            
        }
        
    }

    void UseButton(Ability a)
    {
        CanvasListener.instance.movesMenu.SetActive(false);
        CanvasListener.instance.pauseMenu.SetActive(true);
        CanvasListener.instance.unPause();
        a.OnClick();
    }
}
