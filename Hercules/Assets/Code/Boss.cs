using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //variables needed:
    //the boss
    //the player
    //the interval between enemy attacks
    public float attackInterval;
    public GameObject hand;
    public float pullRange;
    public float pullIntensity;
    public int spawnCount;

    // Boss Health
    public float bossHealth;
    public Image healthBar;

    public GameObject[] enemyPrefabs;
    private int numEnemies;

    private GameObject player;
    private Rigidbody2D playerBody;
    private Transform playerTransform;

    private float time;

    void Start()
    {
        //initialize necessary variables
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerBody = player.GetComponent<Rigidbody2D>();
        numEnemies = enemyPrefabs.Length - 1;

        //start coroutine Attack
        StartCoroutine("Attack");
    }

    void Update()
    {
        //update the interval based on the "difficulty" of the boss
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval); //timed to the interval

            //randomly generate a number between one and three
            int attackChoice = Random.Range(0, 3);

            //if one, calls attack 1 method
            if (attackChoice == 1)
            {
                attackOne();
            }
            //if two, calls attack 2 method
            else if (attackChoice == 2)
            {
                attackTwo();
            }
            //if three, calls attack 3 method
            else
            {
                //attackThree();
            }
        }
    }

    //spawn hands
    void attackOne()
    {
        Debug.Log("attack one");

        //pick five random locations on the map
        //make sure that none of them are the same location, or replace them with a new location until all five are unique
        //spawn a BossHand object (BossHand will have to destroy itself and do damage to the player)

        List<float> allX = new List<float>();
        List<float> allY = new List<float>();

        int i = 0;

        while (i < 5) //https://discussions.unity.com/t/instantiating-gameobjects-at-random-screen-positions/633835
        {
            float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            if (!(allX.Contains(x)) || !(allY.Contains(y))) //if this exact point isn't already selected
            {
                //spawn the hand
                Instantiate(hand, new Vector2(x, y), Quaternion.identity);

                allX.Add(x); //and now no other hand can spawn at this point
                allY.Add(y);

                i++;
            }
        }
    }
    
    //vacuum
    void attackTwo() //https://www.youtube.com/watch?v=E6n-8jp-ZAY
    {
        Debug.Log("attack two");
        //get the location of the player
        Vector2 playerLocation = playerTransform.position;
        Vector2 bossLocation = transform.position;

        //if the location of the player is within the boss's range
        float distance = Vector2.Distance(playerLocation, bossLocation);
        Debug.Log("distance: " + distance);

        //continuously apply a force on the player towards the boss
        //also if the player is within range, call player take damage every second
        if (distance < pullRange)
        {
            Vector2 force = ((bossLocation - playerLocation).normalized / distance) * pullIntensity;
            playerBody.AddForce(force * 500, ForceMode2D.Force);
        }
    }

    //spawn enemies
    void attackThree()
    {
        Debug.Log("attack three");

        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, numEnemies);

            float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Instantiate(enemyPrefabs[randomIndex], new Vector2(x, y), Quaternion.identity);
        }
    }
    
    public void takeDamage(float damage)
    {
        bossHealth -= damage;
        healthBar.fillAmount = Mathf.Clamp(bossHealth / 100, 0, 1);

        if (bossHealth <= 0)
        {
            //end the game
            Debug.Log("Boss defeated");
        }
    }
}
