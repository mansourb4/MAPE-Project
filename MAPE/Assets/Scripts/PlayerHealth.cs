using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
   // public Animator anim;
   public InstantiatePlayer instancePlayer;
   

    public HealthBar healthBar;
    public InventoryItemController itemController;
    
    void Start()
    {
        instancePlayer = InstantiatePlayer.Instance;

        maxHealth = InstantiatePlayer.Instance.maxHealth;
        currentHealth = InstantiatePlayer.Instance.currentHealth;
        healthBar = InstantiatePlayer.Instance.healthBar;
            
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        if (instancePlayer.armor)
        {
            maxHealth = 120;
        }
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        if (instancePlayer.toHeal != 0)
        {
            Heal(instancePlayer.toHeal);
            instancePlayer.toHeal = 0;
        }
        
        /*
        Death();
        /*if (anim.GetBool("Destroygo") is true)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
        */
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Death();
    }

    public void Heal(int healPoint)
    {
        currentHealth += healPoint;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            
           // anim.SetTrigger("isDead");  
         
        }
    }
}
