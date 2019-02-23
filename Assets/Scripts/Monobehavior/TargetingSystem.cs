using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    #region singleton
    public static TargetingSystem instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Sprite sprite;    
    public LayerMask blockingLayer;         //Layer on which collision will be checked.


    private AOEAttack aoe;
    private int horizontal;
    private int vertical;
    private List<GameObject> targets = new List<GameObject>();
    private List<Enemy> enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {    
        if (GameManager.instance.playerTargeting)
        {            
                        
            if ((int) Input.GetAxisRaw("Horizontal") != 0)
            {
                horizontal = (int)Input.GetAxisRaw("Horizontal");
                vertical = 0;
                horizontal = horizontal / Mathf.Abs(horizontal);
                Quaternion rotation = new Quaternion();
                rotation.eulerAngles = new Vector3(0, 90 - 90 * horizontal, 0);
                gameObject.transform.rotation = rotation;
                CreateTargets(horizontal, vertical);                
                return;
            }
            if ((int)Input.GetAxisRaw("Vertical") != 0)
            {
                vertical = (int)Input.GetAxisRaw("Vertical");
                horizontal = 0;
                CreateTargets(horizontal, vertical);
                return;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                HideTargeting();                
                aoe.UseAbility();
                FindTargets();
                foreach (Enemy enemy in enemies)
                {
                    aoe.hitIndicator.target = enemy;
                    aoe.hitIndicator.UseAbility();
                }
                GameManager.instance.playerTargeting = false;
                ExitTargeting();
            }
        }
    }
    // Update is called once per frame
    public void EnterTargeting(AOEAttack attack)
    {
        GameManager.instance.playerTargeting = true;
        aoe = attack;

        CreateTargets(1, 0);
    }

    public void CreateTargets(int horizontal, int vertical)
    {
        if (targets.Count > 0)
            ExitTargeting();
        for (int j = 1; j <= aoe.range; j++)
            for (int i = 1; i <= aoe.width; i++)
            {
                GameObject target = new GameObject("Target Indicator");                
                target.tag = "Target";
                target.layer = 8;
                target.transform.SetParent(gameObject.transform, false);
                SpriteRenderer spriteRenderer = target.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                target.transform.position = new Vector3(j*horizontal + (Mathf.FloorToInt(i / 2)) * Mathf.Pow(-1, i) * vertical, j * vertical + (Mathf.FloorToInt(i / 2)) * Mathf.Pow(-1, i) * horizontal, 0) + gameObject.transform.position;                
                RaycastHit2D hit = Physics2D.Linecast(target.transform.position, gameObject.transform.position, blockingLayer);
                if (hit.transform != null)
                    if (hit.transform.tag == "Wall")
                    {                        
                        Destroy(target);
                        continue;
                    }
                    else if (hit.transform.tag != "Normal Enemy" && hit.transform.position - new Vector3(0, 0, hit.transform.position.z) == target.transform.position - new Vector3(0, 0, target.transform.position.z))
                    {                                                
                        Destroy(target);
                        continue;
                    }
                target.AddComponent<BoxCollider2D>();
                targets.Add(target);
            }
        if (aoe.rotates)
        {            
            aoe.rotation.eulerAngles = new Vector3(0, (90 - 90 * horizontal) * (-horizontal), 90 * vertical);
        }
        aoe.startPosition = new Vector3(horizontal * aoe.offset, vertical * aoe.offset, 0) + transform.position;
    }

    public void FindTargets()
    {
        enemies = new List<Enemy>();
        Collider2D[] results = new Collider2D[aoe.range * aoe.width];        
        foreach (GameObject target in targets)
        {
            BoxCollider2D bc2d = target.GetComponent<BoxCollider2D>();
            bc2d.OverlapCollider(new ContactFilter2D(), results);
        }
        foreach (Collider2D result in results)
        {
            Debug.Log(result);
            if(result != null)
            if (result.gameObject.GetComponent<Enemy>() != null)
            {                 
                 enemies.Add(result.gameObject.GetComponent<Enemy>());
            }
        }
    }

    public void ExitTargeting()
    {
        foreach (GameObject target in targets)
        {            
            DestroyImmediate(target);
        }
        targets = new List<GameObject>();        
    }

    private void HideTargeting()
    {
        foreach(GameObject target in targets)
        {
            target.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
