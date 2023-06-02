using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay2 : MonoBehaviour
{
    public GameObject Enemy;
    public int health;
    public int maxHealth = 100;
    void Start()
    {
        gameObject.SetActive(true);
        GameObject Enemyclone = Instantiate(Enemy);
        health = maxHealth;
        Destroy(gameObject,5);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
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
