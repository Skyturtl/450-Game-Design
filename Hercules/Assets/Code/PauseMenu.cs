using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    private Controller controller;
    private PlayerInventory playerInventory;
    private Flipping flipping;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        
        Debug.Log(flipping);
    }

    // Update is called once per frame
    void Update()
    {
        flipping = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Flipping>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                ResumeGame();
            }
            else
            {
                pauseMenu.SetActive(true);
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        controller.hideInstructions();
        playerInventory.enabled = false;
        controller.enabled = false;
        flipping.enabled = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {      
        pauseMenu.SetActive(false);
        controller.showInstructions();
        playerInventory.enabled = true;
        controller.enabled = true;
        flipping.enabled = true;
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void RestartGame()
    {
        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.player);
            Destroy(PlayerManager.instance.uiCanvas);

        }
        SceneManager.LoadScene(2);
    }
    
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
