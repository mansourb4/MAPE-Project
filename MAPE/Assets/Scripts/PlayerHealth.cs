using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
   

    public HealthBar healthBar;
    
    void Start()
    {
        
        maxHealth = InstantiatePlayer.Instance.maxHealth;
        currentHealth = InstantiatePlayer.Instance.currentHealth;
        healthBar = InstantiatePlayer.Instance.healthBar;
            
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        Death();
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Death();
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
