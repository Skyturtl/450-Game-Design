using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueGetBuff : MonoBehaviour
{
    public Upgrade upgrade;
    private bool isPlayerNearby = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered upgrade zone");
            Controller playerController = FindObjectOfType<Controller>();
            if (playerController != null)
            {
                playerController.ShowInstructionsFromChest("Click E to upgrade");
            }
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Exited");
            isPlayerNearby = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            upgrade.LevelUp();
        }
    }
}
