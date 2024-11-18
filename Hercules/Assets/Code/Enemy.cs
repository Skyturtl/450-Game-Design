using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent<GameObject> OnHitWithReference;
    
    public float ChaseSpeed = 6;
    public float AggroDistance = 12;
    public double StopDistance = 0.5;
    public PlayerHealth pHealth;
    public float damage;
    public float health = 10f;
    public float hitWaitTime = 1f;
    public float dropChance;
    public float dropChanceKey;
    public GameObject[] weaponList;
    public GameObject key;
    private GameObject player;
    public Vector3 dropOffset = new Vector3(0.1f, 0.5f, 0);
    private float hitCounter;
    private Transform target;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if(distance > AggroDistance){
            return;
        }
            
        if(distance <= StopDistance){
            return;
        }

        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * ChaseSpeed * Time.deltaTime;

        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
        if (direction.x <= 0) {
            sprite.flipX = false;
        }

        if (hitCounter > 0f){
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject == target.gameObject && hitCounter <= 0f){
            PlayerHealth.instance.takeDamage(damage, gameObject);
            SoundManager.instance.PlayBite1();
            hitCounter = hitWaitTime;
        }
    }
    
    public void TakeDamage(float damage, GameObject projectile){
        OnHitWithReference?.Invoke(projectile);
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    void Die()
    {
        Upgrade upgrade = player.GetComponent<Upgrade>();
        upgrade.AddKill();
        if(PlayerPrefs.GetInt("CollectedKeys") != 3 && PlayerPrefs.GetInt("dropped") < 3){ 
            ItemDrop();
        }
        Destroy(gameObject);
    }
    
    public void ItemDrop()
    {
        // if(Random.value <= dropChance)
        // {
        //     GameObject weaponToDrop = weaponList[Random.Range(0, weaponList.Length)];
        //     Instantiate(weaponToDrop, transform.position + dropOffset, Quaternion.identity);
        // }
        if(Random.value <= dropChanceKey)
        {   
            PlayerPrefs.SetInt("dropped", PlayerPrefs.GetInt("dropped") + 1);
            Instantiate(key, transform.position + dropOffset, Quaternion.identity);
            if(PlayerPrefs.GetInt("CollectedKeys") == 3){
                dropChanceKey = 0;
            }
        }
    }
}
