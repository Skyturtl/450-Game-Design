using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Outlets
    Rigidbody2D _rigidbody2D;
    public float damageAmount = 5f;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * 20f;
    }
    
<<<<<<< Updated upstream
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
=======
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
            if (other.gameObject.GetComponent<Enemy>().health <= 0)
            {
                Destroy(other.gameObject);
            }
>>>>>>> Stashed changes
            Destroy(gameObject);
        }
    }
}
