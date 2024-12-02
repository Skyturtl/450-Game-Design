using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private TimerUI timerUI;
    private PauseMenu pauseMenu;

    void Start()
    {
        timerUI = FindObjectOfType<TimerUI>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (timerUI != null)
            {
                timerUI.showWin();
                pauseMenu.PauseGame();
            }
        }
    }
}