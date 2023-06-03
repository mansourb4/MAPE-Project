using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycombats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackspeedX, knockbackSpeedY, knockbackDuration;
    [SerializeField]
    private bool applyKnockback;
    private float currentHealth, knockbackStart;

    private PlayerMovement pc;
    private Rigidbody2D rb;
    private Animator anim;
    private int playerFacingDirection;
    private bool playerOnLeft, knockback;
   
    private void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        CheckKnockback();
        
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
        anim.SetBool("playerOnLeft", playerOnLeft);
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
        rb.velocity = new Vector2(knockbackspeedX * playerFacingDirection, knockbackSpeedY);

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
}
