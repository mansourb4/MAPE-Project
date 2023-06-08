using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

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
    public InstantiatePlayer instancePlayer;

    private void Start()
    {
        instancePlayer = InstantiatePlayer.Instance;
    }

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
        bool isController = false;
        if (Gamepad.all.Count > 0)
        {
            isController = true;
        }
        if (Input.GetKey(KeyCode.F) || (isController && Gamepad.all[0].squareButton.wasPressedThisFrame))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 40 + 10 * instancePlayer.nbAttackPotion;
                Attack();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
            _attackPoint.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.B) || (isController && Gamepad.all[0].triangleButton.wasPressedThisFrame))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 35 + 10 * instancePlayer.nbAttackPotion;
                Attack2();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
            _attackPoint.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.V) || (isController && Gamepad.all[0].circleButton.wasPressedThisFrame))
        {
            if(Time.time >= _nextAttackTime)
            {
                _attackPoint.gameObject.SetActive(true);
                damage = 80 + 10 * instancePlayer.nbAttackPotion;
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