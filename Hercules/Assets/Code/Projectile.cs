using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 1f;
    public float maxRange;
    public float ProjectileSpeed;
    private Upgrade upgrade;
    private float damageAmount;
    private Vector3 startPosition;
    //Outlets
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * ProjectileSpeed;
        startPosition = transform.position;
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();

        if(upgrade != null)
        {
            damageAmount = damage + upgrade.attackPower;
        }
    }

    private void Update()
    {
        float traveledDistance = Vector3.Distance(startPosition, transform.position); 

        if (traveledDistance >= maxRange) 
        {
            Destroy(gameObject); 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount, this.gameObject);
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            enemyRigidbody.velocity = Vector2.zero;
        }
        else if(collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().takeDamage(damageAmount);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount, this.gameObject);
            //Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            //enemyRigidbody.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().takeDamage(damageAmount);
        }
    }
    public void UpdateAttackPower(float newAttackPower)
    {
        damageAmount = newAttackPower + damage;
    }
}
