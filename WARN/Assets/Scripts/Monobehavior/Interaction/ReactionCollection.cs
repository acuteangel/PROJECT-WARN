using UnityEngine;
using System.Collections.Generic;

public class ReactionCollection : MonoBehaviour
{
    public List<Reaction> reactions = new List<Reaction>();


    private void Start()
    {
        for (int i = 0; i < reactions.Count; i++)
        {            
            reactions[i].Init();
        }
    }


    public void React(Interactable interactable)
    {
        for (int i = 0; i < reactions.Count; i++)
        {
            reactions[i].React(interactable);
        }
    }
}
