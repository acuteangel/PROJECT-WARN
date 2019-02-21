using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reaction/Damage")]
public class DamageReaction : Reaction
{
    public string aName;
    public int damage;    


    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction(Interactable interactable)
    {
        if (interactable.GetComponent<TriggerInteractable>() != null)
        {
            TriggerInteractable triggerInteractable = interactable.GetComponent<TriggerInteractable>();
            triggerInteractable.character.stats.LoseHealth(damage);
        }
    }

    protected override void ImmediateReaction(MovingObject interactable)
    {
        if (interactable.GetComponent<TriggerInteractable>() != null)
        {
            TriggerInteractable triggerInteractable = interactable.GetComponent<TriggerInteractable>();
            triggerInteractable.character.stats.LoseHealth(damage);
        }
    }
}
