using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public int damage = 15;
    public Vector2 moveSpeed = new Vector2(3f,0);
    public Vector2 knockback = new Vector2(0, 0);
    public EnemyHealth4 enemyHealth;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
        Debug.Log(collision.name + "get hit");
        enemyHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
