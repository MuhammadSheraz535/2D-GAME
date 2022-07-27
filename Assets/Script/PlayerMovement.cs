using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirx;    // variable for horizantal motion left and right
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 14f;
    [SerializeField] private float jump_speed = 9f;
    [SerializeField] private LayerMask jumpableGround;
    public enum MovementState { idle,running,jumping,falling};  //similar to array and have index 0 1 2 3 use for animation
    [SerializeField] private AudioSource jumpsoundAffect;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        
         dirx = Input.GetAxisRaw("Horizontal");  //get horiantal axis left or right
        rb.velocity = new Vector2(dirx * speed, rb.velocity.y);  //multiply horizontal axis with speed 


        if (Input.GetButtonDown("Jump") && IsGrounded() )
		{
            jumpsoundAffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
		}

        updateAnimation();


    }

    private void updateAnimation()
	{
        MovementState state;
        if (dirx > 0f)      //running animation play
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)   //running animation play
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;  //idle animation play
        }
        if (rb.velocity.y > .1f)      //jumping animation play
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)   //falling animation play
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

   private bool IsGrounded()   //function check player is grounded or not
	{
     return   Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

	}
}
