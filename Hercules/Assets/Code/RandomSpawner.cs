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

    // Start is called before the first frame update
    private void Start()
    {
        spawnCounter = initialTimeToSpawn;
        target = PlayerHealth.instance.transform;
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
            int random = Random.Range(0, 100);
            int randomIndex;
            if(random < 100){
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

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = minSpawn.position.x;
            }
            else
            {
                spawnPoint.x = maxSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = minSpawn.position.y;
            }
            else
            {
                spawnPoint.y = maxSpawn.position.y;
            }
        }
        return spawnPoint;
    }
}
