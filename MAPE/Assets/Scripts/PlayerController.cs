using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;
    public float jumpSpeed = 30f; 
    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private bool IsTurnedRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        TakeInput();
        Move();
        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            float force = jumpSpeed;
            if(player.velocity.y < 0)
            {
                force -= player.velocity.y;
            }
            player.velocity = new Vector2(player.velocity.x, player.velocity.y + (force + 0.5f * Time.fixedDeltaTime)/ player.mass);
        }
    }

    void TakeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.Space))
        {
            direction += Vector2.up;
        }
            
        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector2.left;
            IsTurnedRight = false;
                
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            IsTurnedRight = true;
        }
    }

    public void Move()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        SetAnimatorMovement(direction);
    }

    void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xdir", direction.x);
        animator.SetFloat("ydir", direction.y);
        animator.SetBool("Right", IsTurnedRight);
        if (direction.x != 0 || direction.y != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}