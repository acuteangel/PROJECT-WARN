using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{

    public CharacterChoice[] characterChoice;

    private int index;
    public Text characterName;

    public Image characterImage;

    // public Animation characterAnimation;

    // public Animator characterAnimator;

    void Start()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");


        for (int i = 0; i < characterChoice.Length; i++)
        {

            characterName.text = characterChoice[i].name;

            characterImage.sprite = characterChoice[i].characterPrefab.transform.GetComponent<SpriteRenderer>().sprite;

            // characterAnimation = characterChoice[i].characterPrefab.transform.GetComponent<Animation>();
        }

        foreach (CharacterChoice c in characterChoice)
        {
            c.characterPrefab.SetActive(false);
        }

        if (characterChoice[index])
            characterChoice[index].characterPrefab.SetActive(true);


    }

    public void LeftArrow()
    {
        characterChoice[index].characterPrefab.transform.GetComponent<Sprite>();

        index--;
        if (index < 0)
            index = characterChoice.Length - 1;

        characterChoice[index].characterPrefab.SetActive(true);
    }

    public void RightArrow()
    {
        characterChoice[index].characterPrefab.SetActive(false);

        index++;
        if (index == characterChoice.Length)
            index = 0;

        characterChoice[index].characterPrefab.SetActive(true);
    }
}
