using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackpointLeft4 : MonoBehaviour
{
    public EnemyHealth4 enemyHealth;
    public Kettewen_mouvements kettewen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("attaquer");
        enemyHealth.TakeDamage(kettewen.damage);

    }
}
