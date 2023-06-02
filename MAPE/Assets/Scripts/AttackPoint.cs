using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public Enemies enemyHealth;
    public PlayerCombat player;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("Ennemi attaqué");
        enemyHealth.GetComponent<Enemies>().TakeDamage(player.damage);
       
    }
}