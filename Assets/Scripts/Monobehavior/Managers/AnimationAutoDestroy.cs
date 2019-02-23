using UnityEngine;
using System.Collections;

public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 1f;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y * -100 + 50;
        //delay = 2f + GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        GameManager.instance.ChangeTurn(delay);
        Destroy(gameObject, delay);
    }
}