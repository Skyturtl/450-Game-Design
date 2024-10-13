using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Sprite closedChest;
    public Sprite openChest;
    private SpriteRenderer Chest;
    private bool isPlayerNearby = false ;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Chest = GetComponent<SpriteRenderer>();
        Chest.sprite = closedChest;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenChestAct();
        }
    }

    private void OpenChestAct()
    {
        if (!isOpen)
        {
            Chest.sprite = openChest;
            isOpen = true;
            Debug.Log("Chest Opened");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the chest. Press E to open");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
