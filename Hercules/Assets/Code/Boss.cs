using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float attackInterval;
    public float pullRange;
    public float pullIntensity;
    public int handSpawnCount;
    public int mobSpawnCount;

    public GameObject[] enemyPrefabs;
    public GameObject[] handPrefabs;
    public GameObject signPrefab;
    private int numEnemies;
    private int numHands;

    private GameObject player;
    private Rigidbody2D playerBody;
    private Transform playerTransform;

    //DoT Interval Tracking
    public float damageInterval;
    public float onContactDamage;
    private float timePassed;

    void Start()
    {
        //initialize necessary variables
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerBody = player.GetComponent<Rigidbody2D>();
        numEnemies = enemyPrefabs.Length;
        numHands = handPrefabs.Length;

        timePassed = 0;

        //start coroutine Attack
        StartCoroutine("Attack");
    }

    void Update()
    {
        //update the interval based on the "difficulty" of the boss
    }

    //on collision stay
    //if colliding with the player
    //deal X damage every half second
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colliding");
            timePassed += Time.deltaTime;
            if(timePassed >= damageInterval)
            {
                other.gameObject.GetComponent<PlayerHealth>().takeDamage(onContactDamage, gameObject);
                timePassed = 0;
                Debug.Log("DoT");
            }
        }
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
                StartCoroutine(attackOne());
            }
            //if two, calls attack 2 method
            else if (attackChoice == 2)
            {
                attackTwo();
            }
            //if three, calls attack 3 method
            else
            {
                attackThree();
            }
        }
    }

    //spawn hands
    IEnumerator attackOne()
    {
        //Debug.Log("attack one");

        //pick five random locations on the map
        //make sure that none of them are the same location, or replace them with a new location until all five are unique
        //spawn a BossHand object (BossHand will have to destroy itself and do damage to the player)

        List<float> allX = new List<float>();
        List<float> allY = new List<float>();

        int i = 0;

        while (i < handSpawnCount) //https://discussions.unity.com/t/instantiating-gameobjects-at-random-screen-positions/633835
        {
            float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            if (!(allX.Contains(x)) || !(allY.Contains(y))) //if this exact point isn't already selected
            {
                GameObject sign = Instantiate(signPrefab, new Vector2(x + 1.4f, y-3), Quaternion.identity);
                allX.Add(x); //and now no other hand can spawn at this point
                allY.Add(y);
                yield return new WaitForSeconds(0.5f);

                Destroy(sign);

                //spawn the hand
                int randomIndex = Random.Range(0, numHands);
                //Debug.Log(randomIndex);

                Instantiate(handPrefabs[randomIndex], new Vector2(x, y), Quaternion.identity);

                

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
        //Debug.Log("distance: " + distance);

        //continuously apply a force on the player towards the boss
        //also if the player is within range, call player take damage every second
        if (distance < pullRange)
        {
            Vector2 force = ((bossLocation - playerLocation).normalized / distance) * pullIntensity;
            playerBody.AddForce(force * 500, ForceMode2D.Force);
            playerBody.velocity = new Vector2(0, 0);
        }
    }

    //spawn enemies
    void attackThree()
    {
        //Debug.Log("attack three");

        for (int i = 0; i < mobSpawnCount; i++)
        {
            int randomIndex = Random.Range(0, numEnemies);

            float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Instantiate(enemyPrefabs[randomIndex], new Vector2(x, y), Quaternion.identity);
        }
    }
    
    public void takeDamage(float damage)
    {
        BossHealth.instance.takeDamage(damage);
    }
}
