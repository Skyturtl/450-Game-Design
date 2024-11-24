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
    public PlayerInventory playerInventory;

    private int weaponType;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        weaponType = checkWeaponType();
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
        else
        {
            Debug.Log("NO Player Health");
        }
    }

    private void SyncAttackPowerWithPlayer()
    {
        if(weaponType == 2)
        {
            Projectile projectile = GameObject.FindWithTag("Projectile").GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.UpdateAttackPower(attackPower);
            }
        }else if(weaponType == 1)
        {
            MeleeWeapon meleeWeapon = GameObject.FindWithTag("Player").GetComponentInChildren<MeleeWeapon>();
            if (meleeWeapon != null)
            {
                meleeWeapon.UpdateAttackPower(attackPower);

            }
            else
            {
                Debug.Log("No Melee Weapon");
            }
        }else if(weaponType == 3)
        {
            Projectile projectile = GameObject.FindWithTag("Projectile").GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.UpdateAttackPower(attackPower);
            }
            MeleeWeapon meleeWeapon = GameObject.FindWithTag("Player").GetComponentInChildren<MeleeWeapon>();
            if (meleeWeapon != null)
            {
                meleeWeapon.UpdateAttackPower(attackPower);

            }
        }
        
        
    }

    int checkWeaponType()
    {
        if(playerInventory.currentWeapon != null)
        {
            if (playerInventory.currentWeapon.CompareTag("MeleeWeapon"))
            {
                return 1;
            }
            else if (playerInventory.currentWeapon.CompareTag("RangedWeapon")){
                return 2;
            }else if (playerInventory.currentWeapon.CompareTag("MixedWeapon"))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return -1;
        }
    }
}
