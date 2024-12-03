using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject item;
    public float timePassed = 0f;
    private bool timerIsRunning = false;
    private Collider2D itemCollider;
    public GameObject gameWonMenu;
    public TMP_Text timeTaken;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            timePassed += Time.deltaTime;
            DisplayTime(timePassed);
        }
    }

    public void showWin()
    {
        Controller controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        controller.hideInstructions();
        timerIsRunning = false;
        
        gameWonMenu.SetActive(true);
        Time.timeScale = 0f;
        enabled = false;
        totalTime = timePassed;

        float min = Mathf.FloorToInt(totalTime / 60);
        float sec = Mathf.FloorToInt(totalTime % 60);

        timeTaken.text = "Time Taken: " + string.Format("{0:00}:{1:00}", min, sec);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
