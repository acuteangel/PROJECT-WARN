using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 


using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    public float turnDelay = 0.1f;

    [HideInInspector]public int level = 1;
    [HideInInspector]public static GameManager instance = null;
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public bool playersTurn = true;
    [HideInInspector] public bool playerTargeting = false;
    [HideInInspector] public bool doingAnimation = false;    
    public Transform spellCast;
    public Queue<Ability> abilities;    

    #region GameManager Events to subscribe to
    public delegate void GameEventDelegate();
    
    #endregion

    private List<Enemy> enemies = new List<Enemy>();
    private bool enemiesMoving;
    private bool enemiesAttacking;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        abilities = new Queue<Ability>();
    
    }

    //Initializes the game for each level.
    public void InitGame()
    {
        level++;
        CanvasListener.instance.level.text = level.ToString();
        //Assign enemies to a new List of Enemy objects.
        enemies = new List<Enemy>();
    }

    //Update is called every frame.
    void Update()
    {
        //Check that playersTurn or enemiesMoving or doingSetup are not currently true.
        if (playersTurn || enemiesMoving || doingAnimation)
        {            
            //If any of these are true, return and do not start MoveEnemies.
            return;
        }
        if (enemiesAttacking)
        {
            EnemiesAttack();            
            return;
        }
       
        
        //Start moving enemies.
        StartCoroutine(MoveEnemies());
        TimeAllBuffs();
    }

    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
    }

    public void RemoveEnemyFromList(Enemy script)
    {
        //Remove Enemy from List enemies.
        enemies.Remove(script);
    }

    public void GameOver()
    {
        enabled = false;
        Destroy(CanvasListener.instance.gameObject);
        SceneManager.LoadScene(2);
    }

    //Coroutine to move enemies in sequence.
    IEnumerator MoveEnemies()
    {
        //While enemiesMoving is true player is unable to move.
        enemiesMoving = true;

        //Wait for turnDelay seconds, defaults to .1 (100 ms).
        yield return new WaitForSeconds(turnDelay);

        //If there are no enemies spawned (IE in first level):
        if (enemies.Count == 0)
        {
            //Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
            yield return new WaitForSeconds(turnDelay);
        }

        //Loop through List of Enemy objects.
        for (int i = 0; i < enemies.Count; i++)
        {
            //Call the MoveEnemy function of Enemy at index i in the enemies List.
            enemies[i].MoveEnemy();

            //Wait for Enemy's moveTime before moving next Enemy, 
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        
        if (abilities.Count > 0)
        {
            enemiesAttacking = true;   
        } else
        {            
            playersTurn = true;
        }
        enemiesMoving = false;
    }

    public void ChangeTurn(float delay)
    {
        StartCoroutine(enumerator(delay));
    }
        
    IEnumerator enumerator(float delay) { 
        yield return new WaitForSeconds(delay);        
        doingAnimation = false;
    }

    private void EnemiesAttack()
    {
        abilities.Dequeue().UseAbility();
        if (abilities.Count == 0)
        {
            enemiesAttacking = false;
            playersTurn = true;
        }
    }

    private void TimeAllBuffs()
    {
        FindObjectOfType<PlayerStats>().BuffTimer();
//        CharacterStats[] characters = FindObjectsOfType<CharacterStats>();
  //      for (var i = 0; i<characters.Length; i++)
    //    {
      //      characters[i].BuffTimer();
        //}
        
    }
}