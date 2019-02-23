using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Ability/Ability")]
public abstract class Ability : ScriptableObject
{

    public string aName = "New Ability";
    public string trigger = "Trigger";
    public int cost = 0;
    [HideInInspector] public Quaternion rotation = new Quaternion();
    [HideInInspector] public MovingObject caster;
    [HideInInspector] public MovingObject target;
    public bool rotates;
    public bool fromCaster;
    //public AudioClip aSound;

    public virtual void UseAbility()
    {
        if (rotates)
        {
            float horizontal = target.transform.position.x - caster.transform.position.x;
            if (horizontal != 0)
                horizontal = horizontal / Mathf.Abs(horizontal);
            float vertical = target.transform.position.y - caster.transform.position.y;
            if (vertical != 0)
                vertical = vertical / Mathf.Abs(vertical);
            rotation.eulerAngles = new Vector3(0, (90 - 90 * horizontal) * (-horizontal), 90 * vertical);
        }
        Vector3 location = target.transform.position;
        if (fromCaster)
            location = caster.transform.position;
        Transform prefab = Instantiate(GameManager.instance.spellCast, location, rotation);
        GameManager.instance.doingAnimation = true;
        prefab.gameObject.GetComponent<Animator>().SetTrigger(trigger);
    }

    public abstract void OnClick();
}