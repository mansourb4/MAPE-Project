using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatRight : MonoBehaviour
{
    public Animator animator;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.N)) // lettre a changer 
        {
            Special_Attack();
        } 
    }

    void Attack()
    {
        animator.SetTrigger("Attack_1_right");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Gentaro a attaqué " + enemy.name);
        }
    }

    void Special_Attack()
    {
        
        animator.SetTrigger("Spe");
    }
}
