using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float ChaseSpeed = 6;
    public float AggroDistance = 12;
    public double StopDistance = 0.5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.position);

        if(distance > AggroDistance){
            Debug.Log("Out of range");
            return;
        }
            
        if(distance <= StopDistance){
            Debug.Log("Touching");
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
    }
}
