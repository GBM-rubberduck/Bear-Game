using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    
    float xMovement = 0;
    float jumpValue=0;
    bool isOnGround = false;
    Vector2 targetVelocity = new Vector2(0,0);

    public float movementSpeed = 0.5f;
    public float jumpAmount = 0.001f;

    Animator myAnimator;
    Rigidbody2D playerRigidBody;
    PlayerStateManager playerState;
    // Start is called before the first frame update

    void Start() 
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        myAnimator= GetComponent<Animator>();
        playerState = GetComponent<PlayerStateManager>();

        //myAnimator.SetInteger("AnimationSequenceNumber", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.transform.position you also have transform.position
        //playerRigidBody.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);


        if (collision.gameObject.name.Contains("ground")) {
            isOnGround = true;
            myAnimator.SetInteger("AnimationSequenceNumber", 0);
            //playerRigidBody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("gravity")) {
            jumpAmount = 4;
            
            playerRigidBody.gravityScale = -1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("gravity"))
        {
            playerRigidBody.gravityScale = 1f;
            jumpAmount = 1;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("ground"))
        {
            isOnGround = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    /*------- Week 8: ------  ------  Challenge 3 ------  ------  Intermediate ------
     * 1. Make a new function to check player's direction of movement (xMovement) and flip the player sprite accordingly. 
     * you need to move the logic from below to the new function you made.  
     * 2. When health value changes, update the colour accordingly by calling the ChangeColour function iin ColorChager that you are going to implement.
     */

    /*------- Week 8: ------  ------  Challenge 4 ------  ------  Hard ------
     * 1. Create a new class for controlling animations. You may call it PlayerAnimationController
     * 2. Move the logic for controlling character animation to the new class you made
     * 3. Make a variable to access PlayerAnimationController (tip: similar to how we accessed HealthManager class)
     * 4. From PlaerCharacterController class update PlayerAnimationController to play relevant animation.
     * Update player state from character controller class. 
     */
    PlayerStateManager pls;
    private void FixedUpdate()
    {
        CheckInputs();
        if (xMovement > 0)
        {
            transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
        }
        else if (xMovement < 0)
        {
            transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
        }
        if (isOnGround)
        {
            targetVelocity.Set(xMovement * movementSpeed, jumpValue * jumpAmount);
            if(jumpValue> 0)
            {
                myAnimator.SetInteger("AnimationSequenceNumber", 2);
            }
            else if (xMovement != 0) // This means we are moving
            { 
                myAnimator.SetInteger("AnimationSequenceNumber", 1);
            }
            else if (xMovement == 0)
            {
                myAnimator.SetInteger("AnimationSequenceNumber", 0);

                //Example code for final challenge
                //playerState.currentPlayerState = (int) PlayerStateManager.PLAYER_STATES.idle;

                //if (playerState.currentPlayerState == (int) PlayerStateManager.PLAYER_STATES.running) { 
                //}
            }

        }
        else
        {//any other situation
            targetVelocity.Set(xMovement * movementSpeed, 0);
        }
        playerRigidBody.velocity += targetVelocity;

    }

    /*------- Week 6: ------  ------  Challenge 4 ------  ------  Easy ------
 * 1. Check when the player is pressing down the shiftkey and if so, double the player movementSpeed otherwise set movementSpeed = 0.5f
 * 2. Set player health from the start function here. 
 */
    void CheckInputs() {
        xMovement = Input.GetAxis("Horizontal");
        jumpValue = Input.GetAxis("Jump");
    }
}
