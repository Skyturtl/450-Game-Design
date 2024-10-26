using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent OnHit;
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

        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * ChaseSpeed * Time.deltaTime;

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
            // SoundManager.instance.PlayBite();
            hitCounter = hitWaitTime;
        }
    }
    
    public void TakeDamage(float damage){
        OnHit?.Invoke();
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
