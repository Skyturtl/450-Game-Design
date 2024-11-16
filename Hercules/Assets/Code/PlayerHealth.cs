using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class PlayerHealth : MonoBehaviour
{

    public UnityEvent<GameObject> OnHitWithReference;
    public static event Action OnPlayerDeath;
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    public float playerHealth;
    public float maxHealth;
    public Image healthBar;
    private SpriteRenderer sprite;

    private int flickerAmount; //https://www.youtube.com/watch?v=a-kPqG7G1Jw
    private float flickerDuration;
    private bool takingDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        flickerAmount = 2;
        flickerDuration = 0.15f;
        takingDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 1);        
    }

    public void heal(int healAmount)
    {
        playerHealth += healAmount;
        if(playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
        Debug.Log("Healed" + healAmount);
    }

    public void UpdateMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;

        playerHealth = maxHealth;
    }
    
    public void takeDamage(float damage, GameObject sender){
        if(sender.name == "Fork(Clone)"){
            OnHitWithReference?.Invoke(sender);
        }
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth);

        if(!takingDamage)
        {
            StartCoroutine(Flicker());
        }

        if(playerHealth <= 0){
            OnPlayerDeath?.Invoke();
        }
    }

    IEnumerator Flicker()
    {
        takingDamage = true;
        for (int i = 0; i < flickerAmount; i++)
        {
            sprite.color = new Color(1f, 0, 0, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
            sprite.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
            takingDamage = false;
        }
    }

}
