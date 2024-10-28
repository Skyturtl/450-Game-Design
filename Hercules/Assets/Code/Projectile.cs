using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageAmount = 5f;

    private Upgrade upgrade;
    //Outlets
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * 20f;

        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();

        if(upgrade != null)
        {
            damageAmount = upgrade.attackPower;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount, this.gameObject);
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            enemyRigidbody.velocity = Vector2.zero;
        }
        Destroy(gameObject);
    }

    public void UpdateAttackPower(float newAttackPower)
    {
        damageAmount = newAttackPower;
    }
}
