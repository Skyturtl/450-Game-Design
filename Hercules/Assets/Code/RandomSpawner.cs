using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private Transform target;

    public float initialTimeToSpawn = 3f;
    private float spawnCounter;
    private float timePassed = 0;

    public Transform minSpawn, maxSpawn;
    private Controller controller;

    // Start is called before the first frame update
    private void Start()
    {
        spawnCounter = initialTimeToSpawn;
        target = PlayerHealth.instance.transform;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        spawnCounter -= Time.deltaTime;

        // Adjust the timeToSpawn based on timePassed
        float timeToSpawn = Mathf.Max(0.1f, initialTimeToSpawn - (timePassed / 100));

        if (spawnCounter <= 0)
        {
            if (PlayerPrefs.GetInt("CollectedKeys") == 3)
            {
                Instantiate(enemyPrefabs[2], SelectBottomAndSidesSpawn(), Quaternion.identity);
                spawnCounter = 0.15f;
                return;
            }
            int random = Random.Range(0, 100);
            int randomIndex;
            if(random < 60){
                randomIndex = 0;
            }
            else if(random < 75){
                randomIndex = 1;
            }
            else if(random < 90){
                randomIndex = 2;
            }
            else{
                randomIndex = 3;
            }
            Instantiate(enemyPrefabs[randomIndex], SelectSpawnPoint(), Quaternion.identity);
            spawnCounter = timeToSpawn;
        }

        transform.position = target.position;
    }

    public Vector3 SelectBottomAndSidesSpawn()
    {
        Vector3 spawnPoint = Vector3.zero;
        int random = Random.Range(0, 2);

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, (maxSpawn.position.y + minSpawn.position.y) / 2);
            spawnPoint.x = random == 0 ? minSpawn.position.x : maxSpawn.position.x;
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            spawnPoint.y = minSpawn.position.y;
        }
        return spawnPoint;
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;
        int random = Random.Range(0, 2);

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            spawnPoint.x = random == 0 ? minSpawn.position.x : maxSpawn.position.x;
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            spawnPoint.y = random == 0 ? minSpawn.position.y : maxSpawn.position.y;
        }
        return spawnPoint;
    }
}
