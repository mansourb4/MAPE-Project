using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akomi_mouvements : MonoBehaviour
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
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public bool isAttacking = false;
    public int damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.zero;
        attackPoint = attackPointRight;
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
            player.velocity = new Vector2(player.velocity.x, player.velocity.y + ((force + (0.5f * Time.fixedDeltaTime))/ player.mass));
        }
    }
    

    void TakeInput()
    {
        direction = Vector2.zero;
		if (Input.GetKey(KeyCode.Space))
        {
           direction += Vector2.up;
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.left;
            IsTurnedRight = false;
            attackPoint = attackPointLeft;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            IsTurnedRight = true;
            attackPoint = attackPointRight;
        }
        
        else if (Input.GetKey(KeyCode.F))
        {
            if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                damage = 10;
                Attack2();
                isAttacking = true;
                nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;

        }
        else if (Input.GetKey(KeyCode.B))
        {
            if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                damage = 10;
                Attack3();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;
        }
        else if (Input.GetKey(KeyCode.V))
        {
            if(Time.time >= nextAttackTime)
                {
                attackPoint.gameObject.SetActive(true);
                damage = 10;
                Special_Attack();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            attackPoint.gameObject.SetActive(false);
            isAttacking = false;

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

    void Attack2()
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

    void Attack3()
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

    void Special_Attack()
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
   
}