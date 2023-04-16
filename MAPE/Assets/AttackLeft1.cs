using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLeft1 : MonoBehaviour
{
    public EnnemieHealth2 enemyHealth;
    public Akomi_mouvements akomi;
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
        enemyHealth.TakeDamage(10);

    }
}
