using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 _direction = Vector2.zero;
    public Animator animator;
    public float jumpForce = 30f;
    private Rigidbody2D player;
    private bool isTouchingGround;
    private bool IsTurnedRight = true;
    public bool isAttacking = false;
    public BoxCollider2D playerBoxCollider2D;
    public Rigidbody2D playerRigidbody2D;
    public LayerMask platformLayerMask;

    private Vector2 moveValue;

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = IsTouchingGround();
        animator.SetBool("Is_Jumping", !isTouchingGround);
        animator.SetFloat("Vertical_speed", playerRigidbody2D.velocity.y);
        
        if (animator.GetBool("canMove"))
        {
            transform.Translate(moveValue);
        }
        
        if (moveValue.x < 0)
        {
            IsTurnedRight = false;
        }

        else
        {
            IsTurnedRight = true;
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>() * (Time.deltaTime * speed);
        SetAnimatorMovement(moveValue);
    }

    public void Jump()
    {
        if (isTouchingGround)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
