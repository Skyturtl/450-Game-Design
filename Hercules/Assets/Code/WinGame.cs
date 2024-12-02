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

    public void Win()
    {
        if (timerUI != null)
        {
            timerUI.showWin();
            pauseMenu.PauseGame();
        }
    }
}