using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float maxHealth = 100, knockbackSpeedX = 10, knockbackSpeedY = 5, knockbackDuration = 0.1f, knockbackDeathSpeedX = 15, knockbackDeathSpeedY = 8 , deathTorque =  1;
    private float _currentHealth, knockbackStart;
    private PlayerController pc;
    private GameObject Enemy;
    private Rigidbody2D rbEnemy;
    private Animator anim;
    private int playerFacingDirection;
    private bool playerOnLeft, knockback;
    private bool applyKnockback = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        Enemy = transform.Find("Enemy").gameObject;
        anim = Enemy.GetComponent<Animator>();
        rbEnemy = Enemy.GetComponent<Rigidbody2D>();
        Enemy.SetActive(true);
    }
	private void Update()
	{
        CheckKnockback();
	}

	public void TakeDamage(int damage)
  {
        _currentHealth -= damage;
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
        if (applyKnockback && _currentHealth > 0.0f)
        {
            Knockback();
        }
        if (_currentHealth <= 0.0f)
        {
            Die();
        }
  }
  private void Die()
  {
        Debug.Log("Enemy died!");
        Enemy.SetActive(false);
        
  }
    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbEnemy.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
    }
    private void CheckKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbEnemy.velocity = new Vector2(0.0f, rbEnemy.velocity.y);
        }
    }
}
