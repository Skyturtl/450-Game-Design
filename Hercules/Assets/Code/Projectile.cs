using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageAmount = 5f;
    //Outlets
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * 20f;
    }
    
    private void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
            if(other.gameObject.GetComponent<Enemy>().health <= 0){
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
