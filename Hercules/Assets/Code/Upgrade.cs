using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    public int KillCount = 0;
    public int Level = 1;
    public float attackPower = 5f;
    public float maxHealth = 100f;
    public float currentHealth;

    public int killsPerLevel = 10;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill()
    {
        KillCount++;

    }

    public void LevelUp()
    {
        Level++;
        KillCount = 0;

        attackPower += 200f;
        maxHealth += 10f;

        currentHealth = maxHealth;

        SyncAttackPowerWithPlayer();

        SyncHealthWithPlayer();
    }

    private void SyncHealthWithPlayer()
    {
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.UpdateMaxHealth(maxHealth);
        }
    }

    private void SyncAttackPowerWithPlayer()
    {
        Projectile projectile = GameObject.FindWithTag("Projectile").GetComponent<Projectile>();
        MeleeWeapon meleeWeapon = GameObject.FindWithTag("MeleeWeapon").GetComponent<MeleeWeapon>();

        if(projectile != null)
        {
            projectile.UpdateAttackPower(attackPower);
        }
        if(meleeWeapon != null)
        {
            meleeWeapon.UpdateAttackPower(attackPower);
            
        }
    }
}
