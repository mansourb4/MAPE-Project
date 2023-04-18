using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gentaro_mouvements : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    public Animator animator;
    public float jumpForce = 30f; 
	private Rigidbody2D player;
    private bool isTouchingGround;
    private bool IsTurnedRight = true;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public bool isAttacking = false;
    public int damage = 0;
    public BoxCollider2D playerBoxCollider2D;
    public Rigidbody2D playerRigidBody2D;
    public LayerMask platformLayerMask;
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
        attackPoint = attackPointRight;
    }

    // Update is called once per frame
    
    void Update()
    {
        isTouchingGround = IsTouchingTheGround();
        TakeInput();
        animator.SetBool("Is_Jumping", !isTouchingGround);
        animator.SetFloat("Vertical_speed", playerRigidBody2D.velocity.y);
        if (CanMove)
        {
            Move();
        }
    }
    

    void TakeInput()
    {
        direction = Vector2.zero;
		if (Input.GetKey(KeyCode.Space))
        {
           direction += Vector2.up;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.left;
            IsTurnedRight = false;
            attackPoint = attackPointLeft;

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            IsTurnedRight = true;
            attackPoint = attackPointRight;
        }
         if (Input.GetKey(KeyCode.F))
        {
            if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                damage = 10;
                     Attack();
                isAttacking = true;
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;
            
            
        }
        
        if (Input.GetKey(KeyCode.B))
        {
            damage = 25;
            if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                Attack_2();
                isAttacking = true;
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;
            
            
        }
        if (Input.GetKey(KeyCode.V))
        {
            damage = 40;
             if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                isAttacking = true;
                     Attack_3();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;
        }
        if(Input.GetKeyDown(KeyCode.W) && isTouchingGround)
        {
            /*
            float force = jumpForce;
            if(playerRigidbody2D.velocity.y < 0)
            {
                force -= playerRigidbody2D.velocity.y;
            }
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, playerRigidbody2D.velocity.y + ((force + (0.5f * Time.fixedDeltaTime))/ playerRigidbody2D.mass));
            */
            
            playerRigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
	}

    void Move()
    {
        transform.Translate(Time.deltaTime * speed * direction);
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
    void Attack()
        {
        
        if (IsTurnedRight)
            {
                animator.SetTrigger("Attack_1_right");
                attackPoint = attackPointRight;
            }
            else
            {
                animator.SetTrigger("Attack_1_left");
                attackPoint = attackPointLeft;
            }
       
        }
            
    
    void SpecialAttack()
    {
        if (IsTurnedRight)
        {
            animator.SetTrigger("Spe");
            attackPoint = attackPointRight;
        }
        else
        {
            animator.SetTrigger("Spe_left");
            attackPoint = attackPointLeft;
        }
         

    }
    
    void Attack_2()
    {
        if (IsTurnedRight)
        {
            animator.SetTrigger("Attack_2_right");
            attackPoint = attackPointRight;
        }
        else
        {
            animator.SetTrigger("Attack_2_left");
            attackPoint = attackPointLeft;
        }
        
       
       
    }
    
    void Attack_3()
    {
        if (IsTurnedRight)
        {
            animator.SetTrigger("Attack_3_right");
            attackPoint = attackPointRight;
        }
        else
        {
            animator.SetTrigger("Attack_3_left");
            attackPoint = attackPointLeft;
        }
    }
    
    private bool IsTouchingTheGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider2D.bounds.center, playerBoxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformLayerMask);
        return !(raycastHit.collider is null); // return if we collide to something
    }
    



}