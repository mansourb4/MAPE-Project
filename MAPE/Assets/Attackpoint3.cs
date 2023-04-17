using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackpoint3 : MonoBehaviour
{
    public EnnemieHealth3 enemyHealth;
    public Heira_mouvements heira;
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
        enemyHealth.TakeDamage(heira.damage);

    }
}
