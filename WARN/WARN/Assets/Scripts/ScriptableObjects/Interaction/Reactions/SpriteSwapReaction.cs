 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Reaction/Toggle")]
public class SpriteSwapReaction : Reaction
{
    public SpriteRenderer renderer;
    public Sprite newSprite;

    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction(Interactable interactable)
    {
        Sprite temp = renderer.sprite;
        renderer.sprite = newSprite;
        newSprite = temp;
    }

    protected override void ImmediateReaction(MovingObject interactable)
    {
        Sprite temp = renderer.sprite;
        renderer.sprite = newSprite;
        newSprite = temp;
    }
}
