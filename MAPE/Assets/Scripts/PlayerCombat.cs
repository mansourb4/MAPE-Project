using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

   
    public float attackRange = 0.5f;
    public float attackRate = 1f;
    private float lastInputTime = Mathf.NegativeInfinity;
    public LayerMask enemyLayers;
    public int damage = 0;
    

    public bool canMove = true;
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1radius, attack1damage, nextAttacktime;
    private bool gotInput , isAttacking;
    private PlayerMovement pm;
    public Enemycombats enemi;
    public Transform[] attackposition;
    private int currentposition;
    


    private void Start()
    {
        nextAttacktime = Time.time;
        pm = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        animator.SetBool("canAttack", combatEnabled);
    }

    void Update()
    {
        pm.IsTurnedRight = animator.GetBool("Right");
        TakeInput();
        CheckAttacks();

        Updatedposition();
    }
    private void Updatedposition()
    {
        if (pm.IsTurnedRight)
        {
            currentposition = 1;
        }
        else
        {
            currentposition = 0;
        }
    }
    void TakeInput()
    {
        if (Input.GetKey(KeyCode.F) && combatEnabled && (Time.time >= nextAttacktime))
        {
            gotInput = true;
            lastInputTime = Time.time;
            nextAttacktime = Time.time + attackRate;




            damage = 40;
                    Attack();
                    
                
              
            
            
        }
        
        if (Input.GetKey(KeyCode.B) && combatEnabled && (Time.time >= nextAttacktime))
        {
            gotInput = true;
            lastInputTime = Time.time;
            nextAttacktime = Time.time + attackRate;


            Attack2();
                
            

            
        }
        
        if (Input.GetKey(KeyCode.V) && combatEnabled && (Time.time >= nextAttacktime))
        {
            gotInput = true;
            lastInputTime = Time.time;
            nextAttacktime = Time.time + attackRate;



            Special_Attack();
               
            
            
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                animator.SetBool("isAttacking",isAttacking);
            }
        }
        if(Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    void Attack()
    {
        if (pm.IsTurnedRight)
        {
            animator.SetTrigger("Attack_1_right");
        }

        else
        {
            animator.SetTrigger("Attack_1_left");
        }
        
        
       
    }
    
    void Attack2()
    {
        if (pm.IsTurnedRight)
        {
            animator.SetTrigger("Attack_2_right");
        }
        else
        {
            animator.SetTrigger("Attack_2_left");
        }
    }
    private void CheckAttackHitbox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackposition[currentposition].position,attack1radius,enemyLayers) ;
        foreach (Collider2D collider in detectedObjects)
        {

            Debug.Log("hit");
            collider.gameObject.GetComponent<Enemycombats>().Damage(damage);
            

        }

    }
     
    

    private void FinishAttack()
    {
        isAttacking = false;
        animator.SetBool("isAttacking",isAttacking);
    }

    void Special_Attack()
    {
        if (pm.IsTurnedRight)
        {
            animator.SetTrigger("Spe_right");
        }
        else
        {
            animator.SetTrigger("Spe_left");
        }    
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackposition[currentposition].position, attack1radius);
        
    }
}