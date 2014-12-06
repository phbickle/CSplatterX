using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
    private bool hasJump;                   //has the player jumped yet?
    private bool isGrounded;                //if the player on the ground or on the air?
    private bool facingRight;               //is the player facing the right side of the screen?
    private float speed;                    //how fast will the player be?
    private float jumpForce;                //how high can the player jump?
    private float pushForce;                //how far away will the player be pushed from the enemy
    private Transform myTransform;          //player's transform component
    private Transform groundCheck;          //helps to check if we are grounded
    private Vector2 jumpMove;               //The jump vector, so that we can apply the jumpForce
    private Vector2 lookBack;               //looking at left side of the screen
    private Vector2 lookForward;            //looking at right side of the screen
    

    void Awake()
    {
        facingRight = true;                                                                         //Player starts looking at the right side
        hasJump = false;                                                                            //Hasn't jumped yet
        isGrounded = false;                                                                         //will automatically change when ground is detected
        speed = 2.5f;                                                                               //initialize speed
        jumpForce = 800.0f;                                                                         //initialize jumpForce
        pushForce = 400.0f;                                                                         //initialize pushForce
        groundCheck = GameObject.FindGameObjectWithTag(Tags.groundCheck).transform;                 //get the groundcheck component
        myTransform = transform;                                                                    //initialize the player's transform component
        jumpMove = new Vector2(0, jumpForce);                                                       //the jump vector
        lookBack = new Vector2(0f, 180.0f);                                                         //
        lookForward = Vector2.zero;
    }

	// Update is called once per frame
	void Update () 
    {
        CheckGround();
        JumpCheck();
        Flip();
	}

    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void JumpCheck()
    {
        //if jump buttom (SpaceBar) is pressed and the character is grounded
        //then jump.
        //Set has jumped to true, so that the player can't jump more than once
        if(Input.GetButtonDown("Jump") && (isGrounded))
        {
            hasJump = true;
        }
    }


    void Jump()
    {
        //If player has jumped, the apply the jump vector
        //reset hasjumped to false
        if(hasJump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            rigidbody2D.AddForce(jumpMove);
            hasJump = false;
        }
    }


    void CheckGround()
    {
        //Check wheter we are touching the ground
        isGrounded = Physics2D.Linecast(myTransform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");                //Axisraw prevents incremental speeds. In other words, speed will be constant since the beginning
        float moveAbs = Mathf.Abs(move);                            //Absolute values of the move variable, it will always be a positive number. This will be used in animation


        //Axisras will return a number ranging from -1, 0 or 1
        //Depending on the value, the player will turn to the specific side
        if(move < 0)
        {
            facingRight = false;
        }
        else if(move > 0)
        {
            facingRight = true;
        }
        //Apply movement using velocity
        rigidbody2D.velocity = new Vector2(move * speed, rigidbody2D.velocity.y);
    }

    void Flip()
    {
        //Turn left or right
        if(!facingRight)
        {
            myTransform.rotation = Quaternion.Euler(lookBack);
        }
        else if(facingRight)
        {
            myTransform.rotation = Quaternion.Euler(lookForward);
        }
    }

    //Use colliders in order to trigger enemy contact response
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == Tags.enemy)
        {
            //Debug.Log("HITTING SOMETHING HERE");
            PushBack(col.transform);
        }
    }

    //This function is in charge of pushing the player in the opposite direction
    //of the enemy he touched
    void PushBack(Transform enemy)
    {
        Vector3 pushVector = myTransform.position - enemy.position;
        rigidbody2D.AddForce(pushVector * pushForce);
    }
}
