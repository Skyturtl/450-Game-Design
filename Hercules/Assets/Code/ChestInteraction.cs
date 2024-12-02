using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Sprite closedChest;
    public Sprite openChest;
    public GameObject potionPrefab;
    public Transform spawnPoint;
    public int potionCount = 1;
    public float explosionForce = 5f;
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
            SoundManager.instance.PlayChestOpen();
            isOpen = true;
            Debug.Log("Chest Opened");

            for(int i = 0; i < potionCount; ++i)
            {
                GameObject potion = Instantiate(potionPrefab, spawnPoint.position, Quaternion.identity);

                Rigidbody2D rb = potion.GetComponent<Rigidbody2D>();

                if(rb != null)
                {
                    Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1.5f));
                    rb.AddForce(randomDirection * explosionForce, ForceMode2D.Impulse);

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isOpen == false)
        {
            isPlayerNearby = true;
            Controller playerController = FindObjectOfType<Controller>();
            if (playerController != null)
            {
                playerController.ShowInstructionsInput("Click E to open the chest", Color.white);    
            }
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
