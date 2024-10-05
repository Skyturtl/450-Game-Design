using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject gameOverMenu;

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
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
