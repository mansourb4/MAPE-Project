using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycombat : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackspeedX, knockbackSpeedY, knockbackDuration;
    [SerializeField]
    private bool applyKnockback;
    private float currentHealth, knockbackStart;

    private PlayerController pc;
    private GameObject Enemy;
    private Rigidbody2D rb;
    private Animator anim;
    private int playerFacingDirection;
    private bool playerOnLeft, knockback;
    private void Start()
    {
        currentHealth = maxHealth;

        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        Enemy = transform.Find("Enemy").gameObject;
        anim = Enemy.GetComponent<Animator>();
        rb = Enemy.GetComponent<Rigidbody2D>();
        Enemy.SetActive(true);
    }
    private void Update()
    {
        CheckKnockback();
    }
    private void Damage(float amount)
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
        anim.SetBool("playerOnLeft",playerOnLeft);
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
        Enemy.SetActive(false);
    }
        

}
