using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Enemies;


public class Attackpoint2 : MonoBehaviour
{

    private Collider2D collider;

    private void OnEnable()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
    }

    private void OnDisable()
    {
        collider.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Enemy")) {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(10);
        }
    }
}
}


