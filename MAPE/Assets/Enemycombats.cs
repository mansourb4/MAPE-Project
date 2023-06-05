using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycombats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackspeedX, knockbackSpeedY, knockbackDuration;
    [SerializeField]
    private bool applyKnockback;
    private float currentHealth, knockbackStart, distance;
    public int agroDistance;
    private PlayerMovement pc;
    private Rigidbody2D rb;
    private Animator anim;
    private int playerFacingDirection;
    private bool playerOnLeft, knockback, wallDetected;
    private Vector2 movement;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private LayerMask Plateform;
    [SerializeField]
    private float wallCheckDistance,
                  movementSpeed;
    private void Start()
    {
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
        else if (playerOnLeft)
        {
            movement.Set(-movementSpeed, rb.velocity.y);
            rb.velocity = movement;
        }
        else
        {
            movement.Set(movementSpeed, rb.velocity.y);
            rb.velocity = movement;
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
            anim.SetTrigger("frost_hurt_left");
        }
        else
        {
            playerOnLeft = false;
            anim.SetTrigger("frost_hurt_right");
        }
        
        anim.SetTrigger("damage");
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
            rb.velocity = new Vector2( knockbackspeedX , knockbackSpeedY);
        }
        else
        {
            rb.velocity = new Vector2(-knockbackspeedX, knockbackSpeedY);

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
        this.gameObject.SetActive(false);
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
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x, wallCheck.position.y));
    }

    private void Attack()
    {
        if ((distance <= agroDistance ))
        {
            anim.SetBool("inRange", true);
            anim.SetTrigger("Frost_Guardian_attacking_left");
            
        }
        
            anim.SetBool("inRange", false);
        
    }

}
