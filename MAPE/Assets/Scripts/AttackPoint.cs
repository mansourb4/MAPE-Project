using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public PlayerCombat player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ennemi attaqué");
        enemyHealth.TakeDamage(player.damage);
    }
}