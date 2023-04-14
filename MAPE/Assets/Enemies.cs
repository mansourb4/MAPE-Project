using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealh;
    // Start is called before the first frame update
    void Start()
    {
        currentHealh = maxHealth;
    }

  public void TakeDamage(int damage)
  {
    currentHealh -= damage;
    if (currentHealh <= 0)
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
