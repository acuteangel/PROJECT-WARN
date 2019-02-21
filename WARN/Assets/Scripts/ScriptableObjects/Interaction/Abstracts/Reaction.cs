using UnityEngine;

public abstract class Reaction : ScriptableObject
{
    public void Init()
    {
        SpecificInit();
    }


    protected virtual void SpecificInit()
    { }


    public void React(Interactable interactable)
    {
        ImmediateReaction(interactable);
    }


    protected abstract void ImmediateReaction(Interactable interactable);
    protected abstract void ImmediateReaction(MovingObject interactable);
}
