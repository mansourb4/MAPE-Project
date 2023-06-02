using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    private Transform _attackPoint;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    
    public float attackRange = 0.5f;
    public float attackRate = 1f;
    private float _nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public int damage = 0;
    private bool _isTurnedRight = true;

    public bool canMove = true;
    
    
    
   

    
    
    void Update()
    {
        _isTurnedRight = animator.GetBool("Right");
        TakeInput();

        switch (_isTurnedRight)
        {
            case true:
                _attackPoint = attackPointRight;
                break;
            default:
                _attackPoint = attackPointLeft;
                break;
        }
    }

    void TakeInput()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 40;
                Attack();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
            _attackPoint.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.B))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 35;
                Attack2();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
            _attackPoint.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.V))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 80;
                Special_Attack();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
            _attackPoint.gameObject.SetActive(false);
        }
    }

    void Attack()
    {
        if (_isTurnedRight)
        {
            animator.SetTrigger("Attack_1_right");
        }

        else
        {
            animator.SetTrigger("Attack_1_left");
        }
        
        /*
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Gentaro a attaqué " + enemy.name);
        }
        */
    }
    
    void Attack2()
    {
        if (_isTurnedRight)
        {
            animator.SetTrigger("Attack_2_right");
        }
        else
        {
            animator.SetTrigger("Attack_2_left");
        }
    }

    void Special_Attack()
    {
        if (_isTurnedRight)
        {
            animator.SetTrigger("Spe_right");
        }
        else
        {
            animator.SetTrigger("Spe_left");
        }    
    }

    
}