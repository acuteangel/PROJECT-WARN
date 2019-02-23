using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reaction/StatChange")]
public class StatChangeReaction : Reaction
{
    public string aName;
    public int amount;
    public StatName stat;
    public bool percentage;

    protected override void SpecificInit()
    {
        
    }


    protected override void ImmediateReaction(Interactable interactable)
    {
        if (interactable.GetComponent<TriggerInteractable>() != null)
        {
            TriggerInteractable triggerInteractable = interactable.GetComponent<TriggerInteractable>();            
            triggerInteractable.character.stats.ChangeStat((int)stat, amount, percentage);
        }
    }

    protected override void ImmediateReaction(MovingObject interactable)
    {
        if (interactable.GetComponent<TriggerInteractable>() != null)
        {
            TriggerInteractable triggerInteractable = interactable.GetComponent<TriggerInteractable>();
            triggerInteractable.character.stats.ChangeStat((int)stat, amount, percentage);
        }
    }
}

public enum StatName { Health, Mana }
