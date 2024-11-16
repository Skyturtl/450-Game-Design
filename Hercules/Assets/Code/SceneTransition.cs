using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private TimerUI timerUI;

    void Start()
    {
        timerUI = FindObjectOfType<TimerUI>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (timerUI != null)
            {
                timerUI.SaveTimePassed();
            }
            SceneManager.LoadScene("Boss Stage");
        }
    }
}