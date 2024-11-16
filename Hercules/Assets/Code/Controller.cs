using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //Outlet
    public GameObject projectilePrefab;
    public Transform aimPivot;
    SpriteRenderer sprite;
    public float speed;
    public TextMeshProUGUI instructionText;
    private Shoot script;
    private Coroutine instructionCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayerMovement();
        sprite = GetComponent<SpriteRenderer>();
        // script = GetComponent<Shoot>();
        // script.Start();
        if(SceneManager.GetActiveScene().buildIndex == 1){
            StartCoroutine(ShowInstructions("Use WASD to move", Color.white));
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            StartCoroutine(ShowInstructions("Please.. HElp.... Kill me..", Color.red));
        }
        PlayerPrefs.SetInt("CollectedKeys", 0);
        PlayerPrefs.SetInt("dropped", 0);
    }

    IEnumerator ShowInstructions(string instructions, Color color)
    {
        if (instructionCoroutine != null)
        {
            StopCoroutine(instructionCoroutine);
        }

        instructionCoroutine = StartCoroutine(ShowInstructionsCoroutine(instructions, color));
        yield return instructionCoroutine;
    }

    IEnumerator ShowInstructionsCoroutine(string instructions, Color color)
    {
        instructionText.text = instructions;
        instructionText.enabled = true;
        instructionText.color = color;
        float displayTime = 1.5f;
        float elapsed = 0f;

        while (elapsed < displayTime)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Fade out
        float fadeDuration = 1f;
        Color originalColor = color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            instructionText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        instructionText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (PlayerPrefs.GetInt("CollectedKeys") == 3)
        // {
        //     ShakeScreen();
        // }

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

    public void ShowInstructionsInput(string instructions, Color color)
    {
        StartCoroutine(ShowInstructions(instructions, color));
    }

    public void hideInstructions()
    {
        instructionText.enabled = false;
    }

    public void showInstructions()
    {
        instructionText.enabled = true;
    }

    public void collectedKey()
    {   
        PlayerPrefs.SetInt("CollectedKeys", PlayerPrefs.GetInt("CollectedKeys") + 1);
        ShowInstructionsInput("You found a key! " + PlayerPrefs.GetInt("CollectedKeys") + "/3 ...", Color.red);
    }

    // private void ShakeScreen()
    // {
    //     Debug.Log("Shake");
    // } Not sure how to implement help
}
