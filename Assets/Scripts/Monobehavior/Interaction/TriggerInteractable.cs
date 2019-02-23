using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TriggerInteractable : Interactable
{
    public bool playerOnly;
    [HideInInspector] public MovingObject character;

//    private BoxCollider2D bc2d;    

    private void Start()
    {
  //      bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovingObject>() != null)
        {
            character = collision.gameObject.GetComponent<MovingObject>();
            if (!playerOnly || collision.gameObject.GetComponent<Player>() != null)
                Interact();
        }
    }
}
