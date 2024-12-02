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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Controller playerController = FindObjectOfType<Controller>();
            playerController.ShowInstructionsInput("Click E to heal!", Color.green);  
        }
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
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
