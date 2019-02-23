using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;

    public bool delete = false;
    private int index;
    private void Start()        
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        //Fill Array
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }


        //toggle renderer
        for (int i = 0; i < characterList.Length; i++)
        {   
            characterList[i].SetActive(false);
            if (delete && i != index)
                Destroy(characterList[i]);
        }


        //toggle on selected character
        if (characterList[index])
            characterList[index].SetActive(true);
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
            index = characterList.Length -1;

            characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if(index == characterList.Length)
            index = 0;

            characterList[index].SetActive(true);
    }

    public void EnterButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Main");
    }
}
