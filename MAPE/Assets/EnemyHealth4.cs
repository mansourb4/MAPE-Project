using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth4 : MonoBehaviour
{
    public int Health;
    public int maxHealth = 100;
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);

    }
}
