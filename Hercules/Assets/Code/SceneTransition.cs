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
            if(PlayerPrefs.GetInt("CollectedKeys") != 3){
                other.gameObject.GetComponent<Controller>().ShowInstructionsInput("...A door has been unlocked...", Color.red);
                other.gameObject.GetComponent<Controller>().ShowInstructionsInput(". . . Hurry . . .", Color.red);
                return;
            }
            else if (timerUI != null)
            {
                timerUI.SaveTimePassed();
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("Boss Stage");
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Boss Stage")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); 
            if (player != null)
            {
                
                player.transform.position = new Vector3(-3f, -3f, 0f); 
            }
        }
        if (scene.name == "Game")
        {
            if (PlayerManager.instance != null)
            {
                Destroy(PlayerManager.instance.player);
                Destroy(PlayerManager.instance.uiCanvas);
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}