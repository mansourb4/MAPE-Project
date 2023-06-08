using System;
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
    public bool IsTurnedRight = true;
    public bool isAttacking = false;
    public BoxCollider2D playerBoxCollider2D;
    public Rigidbody2D playerRigidbody2D;
    public LayerMask platformLayerMask;
    public LayerMask enemyLayerMask;
    public static InstantiatePlayer instancePlayer;

    Vector2 _moveValue;
    
    
    private void Start()
    {
        instancePlayer = InstantiatePlayer.Instance;
    }
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
        transform.Translate(_moveValue);
        animator.SetBool("Is_Jumping", !isTouchingGround);
        animator.SetFloat("Vertical_speed", playerRigidbody2D.velocity.y);
    }
    
    public int GetFacingDirection()
    {
        if (IsTurnedRight)
        {
            return 0;
        }

        return 1;
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (CanMove)
        {
            _moveValue = context.ReadValue<Vector2>() * (Time.deltaTime * speed);
            SetAnimatorMovement(_moveValue);
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
