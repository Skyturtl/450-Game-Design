using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private Transform target;

    public float timeToSpawn = 1f;
    private float spawnCounter;

    public Transform minSpawn, maxSpawn;


    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeToSpawn;

        target = PlayerHealth.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0){
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], SelectSpawnPoint()   , Quaternion.identity);
            spawnCounter = timeToSpawn;
        }

        transform.position = target.position;
    }

    public Vector3 SelectSpawnPoint(){
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f , 1f) > 0.5f;

        if(spawnVerticalEdge){
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if(Random.Range(0f, 1f) > 0.5f){
                spawnPoint.x = minSpawn.position.x;
            }else{
                spawnPoint.x = maxSpawn.position.x;
            }
        }
        else{
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if(Random.Range(0f, 1f) > 0.5f){
                spawnPoint.y = minSpawn.position.y;
            }else{
                spawnPoint.y = maxSpawn.position.y;
            }

        }
        return spawnPoint;
    }
}
