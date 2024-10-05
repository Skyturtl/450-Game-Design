using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Outlet
    public GameObject projectilePrefab;
    public Transform aimPivot;
    SpriteRenderer sprite;
    public float speed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayerMovement();
        sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("Shoot", 0f, 0.25f); //https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
    }

    //Shoot called every half-second
    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        Vector3 offset = aimPivot.right * 0.5f; // Adjust the offset distance as needed
        newProjectile.transform.position = transform.position + offset;
        newProjectile.transform.rotation = aimPivot.rotation;
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
}
