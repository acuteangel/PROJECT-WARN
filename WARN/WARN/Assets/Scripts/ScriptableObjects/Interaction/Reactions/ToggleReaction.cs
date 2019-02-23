using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Reaction/Toggle")]
public class ToggleReaction : Reaction
{

    public GameObject[] itemsToToggle;

    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction(Interactable interactable)
    {
        foreach (GameObject item in itemsToToggle)
        {
            item.SetActive(!item.activeInHierarchy);
        }
    }

    protected override void ImmediateReaction(MovingObject interactable)
    {
        foreach (GameObject item in itemsToToggle)
        {
            item.SetActive(!item.activeInHierarchy);
        }
    }
}
