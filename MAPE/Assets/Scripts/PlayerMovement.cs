using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 _direction = Vector2.zero;
    public Animator animator;
    public float jumpForce = 30f;
    private Rigidbody2D player;
    private bool isTouchingGround;
    public bool IsTurnedRight = true;
    public bool isAttacking = false;
    public BoxCollider2D playerBoxCollider2D;
    public Rigidbody2D playerRigidbody2D;
    public LayerMask platformLayerMask;
    public bool CanMove
    {
        get
        {
            return animator.GetBool("canMove");
        }
            
    }
    
    

    // Update is called once per frame
   
    void Update()
    {
        
        isTouchingGround = IsTouchingGround();
        TakeInput();
        
            Move();
        
       
        animator.SetBool("Is_Jumping", !isTouchingGround);
        animator.SetFloat("Vertical_speed", playerRigidbody2D.velocity.y);
        
        
            Move();
        
    }
    public int GetFacingDirection()
    {
        if (IsTurnedRight)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    private void Move()
    {
        if (CanMove)
        {
            transform.Translate(_direction * (speed * Time.deltaTime));
            SetAnimatorMovement(_direction);
        }
        
    }

    private void TakeInput()
    {
        _direction = Vector2.zero;
        if (CanMove)
        {
            if (Input.GetKey(KeyCode.S))
            {
                _direction += Vector2.left;
                IsTurnedRight = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _direction += Vector2.right;
                IsTurnedRight = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
            {
                playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        
        
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
    
    private bool IsTouchingGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider2D.bounds.center, playerBoxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformLayerMask);
        return !(raycastHit.collider is null); // return if we collide to something
    }
}
