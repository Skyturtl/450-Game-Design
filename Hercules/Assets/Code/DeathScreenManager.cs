using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private Controller controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= OnPlayerDeath;
    }
    public void OnPlayerDeath()
    {
        controller.hideInstructions();
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.player);
            Destroy(PlayerManager.instance.uiCanvas);
        }
        SceneManager.LoadScene(1);
        
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
