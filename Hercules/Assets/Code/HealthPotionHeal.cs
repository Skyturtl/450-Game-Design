using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionHeal : MonoBehaviour
{
    public int healAmount = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
