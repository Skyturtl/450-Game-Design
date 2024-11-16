using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");   
        if (other.gameObject == player)
        { 
            Controller controller = player.GetComponent<Controller>();
            controller.collectedKey();
            Destroy(gameObject);
        }
    }
}
