using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/AOE")]
public class AOEAttack : Ability
{
    public int range = 1;
    public int width = 1;
    public Attack hitIndicator;
    public int offset = 0;
    [HideInInspector]public Vector3 startPosition = new Vector3(0, 0, 0);

    public override void UseAbility()
    {
        GameManager.instance.doingAnimation = true;
        Transform prefab = Instantiate(GameManager.instance.spellCast, startPosition, new Quaternion());
        GameManager.instance.playersTurn = false;
        prefab.gameObject.GetComponent<Animator>().SetTrigger(trigger);
    }

    public override void OnClick()
    {
        FindObjectOfType<TargetingSystem>().EnterTargeting(this);
    }
}
