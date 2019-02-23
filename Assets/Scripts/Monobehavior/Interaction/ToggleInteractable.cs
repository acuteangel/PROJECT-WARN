using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteractable : TriggerInteractable
{    
    public GameObject[] itemsToToggle;
    public Sprite spriteToSwap;

    private void Start()
    {
        if (itemsToToggle.Length > 0)
        {
            ToggleReaction toggleReaction = ScriptableObject.CreateInstance<ToggleReaction>();
            toggleReaction.itemsToToggle = itemsToToggle;
            defaultReactionCollection.reactions.Add(toggleReaction);
        }

        if (spriteToSwap != null)
        {
            SpriteSwapReaction spriteSwapReaction = ScriptableObject.CreateInstance<SpriteSwapReaction>();
            spriteSwapReaction.newSprite = spriteToSwap;
            spriteSwapReaction.renderer = GetComponent<SpriteRenderer>();
            defaultReactionCollection.reactions.Add(spriteSwapReaction);
        }
    }

    
}
