using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackpoint : MonoBehaviour
{
   
    public EnemyHealth enemyHealth;
    public Gentaro_mouvements gentaro;
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
            enemyHealth.TakeDamage(gentaro.damage);
        
    }
}
