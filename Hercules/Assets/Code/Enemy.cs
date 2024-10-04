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

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Controller>()){
            target.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
}
