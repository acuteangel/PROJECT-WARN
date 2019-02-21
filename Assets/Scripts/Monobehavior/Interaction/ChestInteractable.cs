using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    
    private void Start()
    {         
        
    }

    public override void Interact()
    {        
        base.Interact();
        Destroy(gameObject);
    }
}
