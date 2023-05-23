using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    private int _currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

  public void TakeDamage(int damage)
  {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
  }
  void Die()
  {
        Debug.Log("Enemy died!");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
  }
}
