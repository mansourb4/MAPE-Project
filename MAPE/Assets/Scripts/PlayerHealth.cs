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
        maxHealth = InstantiatePlayer.instance.maxHealth;
        currentHealth = InstantiatePlayer.instance.currentHealth;
        healthBar = InstantiatePlayer.instance.healthBar;
            
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
