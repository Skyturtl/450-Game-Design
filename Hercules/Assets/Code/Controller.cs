using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    //Outlet
    public GameObject projectilePrefab;
    public Transform aimPivot;
    SpriteRenderer sprite;
    public float speed;
    public TextMeshProUGUI timerText;
    private Shoot script;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayerMovement();
        sprite = GetComponent<SpriteRenderer>();
        script = GetComponent<Shoot>();
        script.Start();
        StartCoroutine(ShowInstructions("Use WASD to move"));
    }

    IEnumerator ShowInstructions(string instructions)
    {
        timerText.text = instructions;
        timerText.enabled = true;
        float displayTime = 3f;
        float elapsed = 0f;

        while (elapsed < displayTime)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Fade out
        float fadeDuration = 1f;
        Color originalColor = timerText.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            timerText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        timerText.enabled = false;
        timerText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //up
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S)) //down
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A)) //left
        {
            sprite.flipX = false;
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) //right
        {
            sprite.flipX = true;
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        //Mouse Aiming
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 directionFromPlayerToMouse = mousePositionInWorld - transform.position;

        float radiansToMouse = Mathf.Atan2(directionFromPlayerToMouse.y, directionFromPlayerToMouse.x);
        float angleToMouse = radiansToMouse * Mathf.Rad2Deg;

        aimPivot.rotation = Quaternion.Euler(0, 0, angleToMouse);
    }
    public void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }

    public void OnDisable()
    {      
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }

    public void DisablePlayerMovement(){
        Time.timeScale = 0f;
        enabled = false;
    }

    public void EnablePlayerMovement(){
        Time.timeScale = 1f;
        enabled = true;
    }

    public void ShowInstructionsFromChest(string instructions)
    {
        StartCoroutine(ShowInstructions(instructions));
    }
}
