﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public int playerDamage;
    public Ability abilityWindup;

    private Animator animator;
    private Transform target;        

    // Start is called before the first frame update
    protected override void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

        //Get and store a reference to the attached Animator component.
        animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;
        abilityWindup.target = this;

        //Call the start function of our base class MovingObject.
        base.Start();
    }

    //Override the AttemptMove function of MovingObject to include functionality needed for Enemy to skip turns.
    //See comments in MovingObject for more on how base AttemptMove function works.
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        //Call the AttemptMove function from MovingObject.
        base.AttemptMove<T>(xDir, yDir);
    }

    //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
    public void MoveEnemy()
    {
        //Declare variables for X and Y axis move directions, these range from -1 to 1.
        //These values allow us to choose between the cardinal directions: up, down, left and right.
        int xDir = 0;
        int yDir = 0;

        //If the difference in positions is approximately zero (Epsilon) do the following:
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)

            //If the y coordinate of the target's (player) position is greater than the y coordinate of this enemy's position set y direction 1 (to move up). If not, set it to -1 (to move down).
            yDir = target.position.y > transform.position.y ? 1 : -1;

        //If the difference in positions is not approximately zero (Epsilon) do the following:
        else
            //Check if target x position is greater than enemy's x position, if so set x direction to 1 (move right), if not set to -1 (move left).
            xDir = target.position.x > transform.position.x ? 1 : -1;

        //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
        AttemptMove<Player>(xDir, yDir);
    }

    //OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
    //and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
    protected override void OnCantMove<T>(T component)
    {
        //Declare hitPlayer and set it to equal the encountered component.
        Player hitPlayer = component as Player;
        ability.target = hitPlayer;
        GameManager.instance.abilities.Enqueue(abilityWindup);
        GameManager.instance.abilities.Enqueue(ability);
    }

    //DamageEnemy is called when the player abilities an enemy.
    public override void LoseHealth()
    {
        GameManager.instance.doingAnimation = true;
        animator.SetTrigger("enemyHit");
        GameManager.instance.ChangeTurn(animator.GetCurrentAnimatorStateInfo(0).length * 2);                

        //If hit points are less than or equal to zero:
        if (stats.currentHealth <= 0)
        {
            //Removes enemy from list
            GameManager.instance.RemoveEnemyFromList(this);
            //Disable the gameObject.
            Destroy(gameObject, 1f);
        }
    }
}
