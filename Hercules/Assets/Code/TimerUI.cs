using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject item;
    public float timePassed = 0f;
    private bool timerIsRunning = false;
    private Collider2D itemCollider;
    public GameObject gameWonMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        timerIsRunning = true;

        itemCollider = item.GetComponent<Collider2D>();

        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }
        else
        {
            Debug.LogError("Item does not have a Collider component.");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            timePassed += Time.deltaTime;

            DisplayTime(timePassed);

            // else
            // {
            //     timeRemaining = 0;
            //     timerIsRunning = false;

            //     gameWonMenu.SetActive(true);
            //     Time.timeScale = 0f;
            //     enabled = false;

            //     if(itemCollider != null)
            //     {
            //         itemCollider.enabled = false;
            //     }
            // }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
