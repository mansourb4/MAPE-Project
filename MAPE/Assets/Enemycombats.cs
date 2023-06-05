using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycombats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackspeedX, knockbackSpeedY, knockbackDuration, radius;
    [SerializeField]
    private bool applyKnockback;
    private float currentHealth, knockbackStart, distance;
    public int agroDistance;
    private PlayerMovement pc;
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    private int playerFacingDirection;
    private bool playerOnLeft, knockback, wallDetected;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private LayerMask Plateform;
    [SerializeField]
    private float wallCheckDistance,
                  movementSpeed;
    private float nextAttacktime ;
    public Transform attackpoint, attackpointr,attackpointl;
    // public PlayerHealth ph;
    public float rate;
    public LayerMask player;
    public int ennemyDamage;
    private int currentposition;
    private void Start()
    {
        nextAttacktime = Time.time;
        anim.SetBool("Dead", false);
        anim.SetBool("inRange", false);
        
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        
        distance = Vector2.Distance(transform.position, pc.transform.position);
        if (pc.transform.position.x > this.gameObject.transform.position.x)
        {
            playerOnLeft = false;
            
        }
        else
        {
            playerOnLeft = true;

        }
        CheckKnockback();
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, Plateform);
        Flip();
        if (wallDetected)
        {
            Flip();
        }
        else if (playerOnLeft )
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        else 
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        
        
        
           
        
        pc.GetFacingDirection();

        Attack();
        
    }
    public void Damage(float amount)
    {
        
        currentHealth -= amount;
        playerFacingDirection = pc.GetFacingDirection();

        if (playerFacingDirection == 1)
        {
            playerOnLeft = true;
           
        }
        else
        {
            playerOnLeft = false;
           
        }
        
       // anim.SetTrigger("damage");
        if (applyKnockback && currentHealth > 0.0f)
        {
            //Knockback
            Knockback();
        }
        if (currentHealth <= 0.0f)
        {
            //Die
            Die();
        }
    }

    private void Knockback()
    {
        
        knockback = true;
        knockbackStart = Time.time;
        

        if (playerOnLeft)
        {
            rb.velocity = new Vector2(- knockbackspeedX , knockbackSpeedY);
        }
        else
        {
            rb.velocity = new Vector2(knockbackspeedX, knockbackSpeedY);

        }


    }

    private void CheckKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }
    private void Die()
    {
        anim.SetBool("Dead", true);
        anim.Play("frost_Death");
        Destroy(gameObject);
    }
    public void FindPlayer()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>());
    }

    private void Flip()
    {
        if (playerOnLeft)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            attackpoint = attackpointr;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            attackpoint = attackpointl;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x, wallCheck.position.y));
    }

    private void Attack()
    {
        
        if ((distance <= agroDistance ) && Time.time >= nextAttacktime)
        {
            
           anim.SetBool("inRange", true);
           anim.Play("Frost_Guardian_attacking_left");
           nextAttacktime = Time.time + rate;
            Collider2D playercollider = Physics2D.OverlapCircle(attackpoint.position, radius);
            playercollider.gameObject.GetComponent<PlayerHealth>().TakeDamage(ennemyDamage);
            Debug.Log("hit");

            
        }
        
        anim.SetBool("inRange", false);
        
    }
    

    private void OnDrawGizmosSelected()
    {
       
        Gizmos.DrawWireSphere(attackpoint.position, radius);

    }

    
        
    
}
