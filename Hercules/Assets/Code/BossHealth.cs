using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static BossHealth instance;

    private void Awake()
    {
        instance = this;
    }

    public float curBossHealth;
    public float maxBossHealth;
    public Image healthBar;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        curBossHealth = maxBossHealth;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(curBossHealth / maxBossHealth, 0, 1);
    }

    public void UpdateMaxHealth(float newMaxBossHealth)
    {
        maxBossHealth = newMaxBossHealth;

        curBossHealth = maxBossHealth;
    }

    public void takeDamage(float damage)
    {
        curBossHealth -= damage;
        Debug.Log("Boss Health: " + curBossHealth);

        if (curBossHealth <= 0)
        {
            //end the game
            Debug.Log("Boss Defeated");
        }
    }
}
