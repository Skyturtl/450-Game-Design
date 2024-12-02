using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueGetBuff : MonoBehaviour
{
    public GameObject upgrade;
    private bool isPlayerNearby = false;
    private Controller controller;
    private bool isUpgrading = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller = FindObjectOfType<Controller>();
            if (controller != null)
            {
                controller.ShowInstructionsInput("Click E to upgrade", Color.white);
            }
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            isUpgrading = false;
            if(upgrade != null){
                upgrade.SetActive(false);
            }
            controller.enabled = true;
            Time.timeScale = 1f;
        }
    }

    void Start()
    {
        upgrade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isUpgrading)
        {
            upgrade.SetActive(true);
            controller.enabled = false;
            Time.timeScale = 0f;
            isUpgrading = true;
        }
        else if(isPlayerNearby && Input.GetKeyDown(KeyCode.E) && isUpgrading)
        {
            upgrade.SetActive(false);
            controller.enabled = true;
            Time.timeScale = 1f;
            isUpgrading = false;
        }
    }
}
