using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gentaro_mouvements : MonoBehaviour
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
                     Attack();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            
            
        }
        
        else if (Input.GetKey(KeyCode.B))
        {
            if(Time.time >= nextAttackTime)
                {
                     Attack_2();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            
            
        }
        else if (Input.GetKey(KeyCode.V))
        {
             if(Time.time >= nextAttackTime)
                {
                     Attack_3();
                     nextAttackTime = Time.time + 1f / attackRate;
                }
            
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
            attackPoint.gameObject.SetActive(true);
            
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemies>().TakeDamage(20);
                Debug.Log("Gentaro a attaqué " + enemy.name);
            }
        
             attackPoint.gameObject.SetActive(false);
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
         attackPoint.gameObject.SetActive(true);
         attackPoint.GetComponent<Collider2D>().enabled = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemies>().TakeDamage(0);
            Debug.Log("Gentaro a attaqué " + enemy.name);
        }
        attackPoint.GetComponent<Collider2D>().enabled = true;
         attackPoint.gameObject.SetActive(false);

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
         attackPoint.gameObject.SetActive(true);
         attackPoint.GetComponent<Collider2D>().enabled = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemies>().TakeDamage(40);
            Debug.Log("Gentaro a attaqué " + enemy.name);
        }
        attackPoint.GetComponent<Collider2D>().enabled = true;
         attackPoint.gameObject.SetActive(false);
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
         attackPoint.gameObject.SetActive(true);
         attackPoint.GetComponent<Collider2D>().enabled = false;
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemies>().TakeDamage(50);
            Debug.Log("Gentaro a attaqué " + enemy.name);
        }
        attackPoint.GetComponent<Collider2D>().enabled = true;
         attackPoint.gameObject.SetActive(false);
    }
    
    
}