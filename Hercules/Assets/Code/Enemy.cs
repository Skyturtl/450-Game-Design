using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float ChaseSpeed = 6;
    public float AggroDistance = 12;
    public double StopDistance = 0.5;
    public PlayerHealth pHealth;
    public float damage;
    public float health = 10f;
    public float hitWaitTime = 1f;
    private float hitCounter;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if(distance > AggroDistance){
            return;
        }
            
        if(distance <= StopDistance){
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, ChaseSpeed * Time.deltaTime);

        Vector3 direction = gameObject.transform.InverseTransformPoint(target.position);
        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
        if (direction.x <= 0) {
            sprite.flipX = false;
        }

        if (hitCounter > 0f){
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject == target.gameObject && hitCounter <= 0f){
            PlayerHealth.instance.takeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
    
    public void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
