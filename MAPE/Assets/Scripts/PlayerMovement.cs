using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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
    public LayerMask enemyLayerMask;

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = IsTouchingGround();
        TakeInput();
        Move();
        animator.SetBool("Is_Jumping", !isTouchingGround);
        animator.SetFloat("Vertical_speed", playerRigidbody2D.velocity.y);
        
        if(animator.GetBool("canMove"))
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        SetAnimatorMovement(_direction);
    }

    private void TakeInput()
    {
        _direction = Vector2.zero;
        bool isController = false;
        if (Gamepad.all.Count > 0)
        {
            isController = true;
        }
        
        if (Input.GetKey(KeyCode.S) || (isController && Gamepad.all[0].leftStick.left.isPressed))
        {
            _direction += Vector2.left;
            IsTurnedRight = false;
        }
        if (Input.GetKey(KeyCode.D)|| (isController && Gamepad.all[0].leftStick.right.isPressed))
        {
            _direction += Vector2.right;
            IsTurnedRight = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || (isController && Gamepad.all[0].circleButton.wasPressedThisFrame)) && isTouchingGround)
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
        RaycastHit2D raycastHitEnemy = Physics2D.BoxCast(playerBoxCollider2D.bounds.center, playerBoxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, enemyLayerMask);
        return !(raycastHit.collider == raycastHitEnemy.collider && raycastHit.collider is null); // return if we collide to something
    }
}
