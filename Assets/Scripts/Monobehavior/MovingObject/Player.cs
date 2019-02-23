using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject
{
    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.
    
    private Animator animator;                  //Used to store a reference to the Player's animator component.    
    private int horizontal;
    private int vertical;

    //Start overrides the Start function of MovingObject
    protected override void Start()
    {        
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();
        
        //Call the Start function of the MovingObject base class.
        base.Start();

        if (GameManager.instance.level > 1)
        {
            SaveData.instance.LoadCharacter();
        }

        CanvasListener.instance.healthBar.maxValue = stats.maxHealth.GetValue();
        CanvasListener.instance.healthBar.value = stats.currentHealth;
        CanvasListener.instance.player = this;
        CanvasListener.instance.manaBar.maxValue = stats.maxMana.GetValue();
        CanvasListener.instance.manaBar.value = stats.currentMana;

    }
    

    private void Update()
    {
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.playersTurn || GameManager.instance.doingAnimation || GameManager.instance.isPaused || GameManager.instance.playerTargeting) return;

        horizontal = 0;     //Used to store the horizontal move direction.
        vertical = 0;       //Used to store the vertical move direction.

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            //Call AttemptMove passing in the generic parameter Enemy, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttemptMove<Enemy>(horizontal, vertical);
        }
    }

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Enemy, it also takes integers for x and y direction to move in.
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        
        //Hit allows us to reference the result of the Linecast done in Move.
        RaycastHit2D hit;
        if (CanAttack(xDir, yDir, out hit))
        {
            GameManager.instance.playersTurn = false;
            return;
        }
        if (CanInteract(xDir, yDir, out hit))
        {
            GameManager.instance.playersTurn = false;
            return;
        }
        //If Move returns true, meaning Player was able to move into an empty space.
        if (Move(xDir, yDir, out hit))
        {
            animator.SetTrigger("playerRun");
            GameManager.instance.playersTurn = false;
            //Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
            return;
        }

        //Call the AttemptMove method of the base class, passing in the component T (in this case Enemy) and x and y direction to move.
        base.AttemptMove<T>(xDir, yDir);
        
    }

    private bool CanAttack(int xDir, int yDir, out RaycastHit2D hit)
    {   
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position + new Vector3(xDir * 0.5f, yDir * 0.5f);
        // Calculate end position based on the direction parameters passed in when calling Move.
        Attack attack = ability as Attack;
        Vector2 end = start - new Vector2(xDir * 0.5f, yDir * 0.5f) + new Vector2(xDir * attack.range, yDir * attack.range);


        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        //boxCollider.enabled = false;

        //Cast a line from start point to end point checking collision on blockingLayer.
        hit = Physics2D.Linecast(start, end, blockingLayer);

        //Re-enable boxCollider after linecast
        //boxCollider.enabled = true;

        //Check if anything was hit
        if (hit.transform != null)
            if (hit.transform.gameObject.GetComponent<MovingObject>() != null)
            {                
                ability.target = hit.transform.gameObject.GetComponent<MovingObject>();
                ability.UseAbility();
                //Return true to say that Attack was successful
                return true;
            }

        //If something was hit, return false, Attack was unsuccesful.
        return false;
    }

    private bool CanInteract(int xDir, int yDir, out RaycastHit2D hit)
    {
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position + new Vector3(xDir * 0.5f, yDir * 0.5f);
        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2(xDir *0.5f, yDir*0.5f);

        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        //boxCollider.enabled = false;

        //Cast a line from start point to end point checking collision on blockingLayer.
        hit = Physics2D.Linecast(start, end, blockingLayer);

        //Re-enable boxCollider after linecast
        //boxCollider.enabled = true;

        //Check if anything was hit
        if (hit.transform != null)
            if (hit.transform.gameObject.GetComponent<Interactable>() != null)
            {
                hit.transform.gameObject.GetComponent<Interactable>().Interact();
                //Return true to say that Interaction was successful
                return true;
            }

        //If something was hit, return false, Move was unsuccesful.
        return false;
    }

    //OnCantMove overrides the abstract function OnCantMove in MovingObject.
    //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
    protected override void OnCantMove<T>(T component)
    {
        //Set hitEnemy to equal the component passed in as a parameter.
        Enemy hitEnemy = component as Enemy;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, (90-90*horizontal)*(-horizontal), 90*vertical);
        ability.target = hitEnemy;
        ability.rotation = rotation;
        ability.UseAbility();        
    }

    //OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerStay2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Exit")
        {
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Invoke("Restart", restartLevelDelay);

            //Disable the player object since level is over.
            enabled = false;            
        }                
    }

    //Restart reloads the scene when called.
    private void Restart()
    {
        //Load the last scene loaded, in this case Main, the only scene in the game.
        SaveData.instance.SaveCharacter();
        SceneManager.LoadScene(1);
        GameManager.instance.InitGame();
    }

    //LoseFood is called when an enemy attacks the player.
    //It takes a parameter loss which specifies how many points to lose.
    public override void LoseHealth()
    {
        //Set the trigger for the player animator to transition to the playerHit animation.
        GameManager.instance.doingAnimation = true;
        animator.SetTrigger("playerHit");
        GameManager.instance.ChangeTurn(animator.GetCurrentAnimatorStateInfo(0).length * 2);
        CanvasListener.instance.UpdateHealthBar();
        //Check to see if game has ended.
        CheckIfGameOver();
    }


    //CheckIfGameOver checks if the player is out of health points and if so, ends the game.
    private void CheckIfGameOver()
    {
        if (stats.currentHealth <= 0)
        {
            animator.SetTrigger("playerHit");
            GameManager.instance.Invoke("GameOver", 2f);
        }
    }
}
