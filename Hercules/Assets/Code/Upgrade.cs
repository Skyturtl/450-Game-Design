using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{

    public int KillCount = 0;
    private GameObject player;
    private PlayerInventory playerInventory;
    public GameObject[] weapons;
    private int weaponIndex = 0;

    // Added values
    public float bulletDamageAdded;
    public float bulletSpeedAdded;
    public float ShotSpeedMultiplier = 1f;
    public float keyDropChance = 0.01f;

    // UI
    public TMP_Text killsText;
    public TMP_Text speedUpgradeText;
    public TMP_Text healthUpgradeText;
    public TMP_Text healthHealText;
    public TMP_Text bulletSpeedText;
    public TMP_Text bulletDamageText;
    public TMP_Text fireRateText;
    public TMP_Text keyDropText;
    public TMP_Text weaponNextText;
    

    // prices
    private int speedUpgradePrice = 3;
    private int healthUpgradePrice = 5;
    private int healthHealPrice = 5;
    private int bulletSpeedPrice = 10;
    private int bulletDamagePrice = 10;
    private int fireRatePrice = 10;
    private int keyDropPrice = 10;
    private int weaponNextPrice = 25;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        playerInventory.PickUpWeapon(weapons[weaponIndex]);
    }

    void Update(){
        killsText.text = "Kills: " + KillCount;
        speedUpgradeText.text = "Movespeed ++\nKills: " + speedUpgradePrice;
        healthUpgradeText.text = "Player HP ++\nKills: " + healthUpgradePrice;
        healthHealText.text = "Heal\nKills: " + healthHealPrice;
        keyDropText.text = "Key Drop ++\n Kills: " + keyDropPrice;
        if(weaponIndex == 0){
            bulletSpeedText.text = "Not Unlocked Yet";
            bulletDamageText.text = "Swing Dmg ++\nKills: " + bulletDamagePrice;
            fireRateText.text = "Swing Speed ++\nKills: " + fireRatePrice;
        }
        else{
            bulletSpeedText.text = "Bullet Speed ++\nKills: " + bulletSpeedPrice;
            bulletDamageText.text = "Bullet Dmg ++\nKills: " + bulletDamagePrice;
            fireRateText.text = "Fire Rate\nKills: " + fireRatePrice;            
        }
        if(weaponIndex >= weapons.Length - 1)
        {
            weaponNextText.text = "Max Weapon!!";
        }
        else{
            weaponNextText.text = "Next Weapon\nKills: " + weaponNextPrice;
        }
    }

    public void speedIncrease()
    {
        if(KillCount >= speedUpgradePrice)
        {
            KillCount -= speedUpgradePrice;
            speedUpgradePrice += 3;
            player.GetComponent<Controller>().speed += 1;
        }
    }

    public void healthIncrease()
    {
        if(KillCount >= healthUpgradePrice)
        {
            KillCount -= healthUpgradePrice;
            healthUpgradePrice += 5;
            player.GetComponent<PlayerHealth>().UpdateMaxHealth(player.GetComponent<PlayerHealth>().maxHealth + 25);
        }
    }

    public void healthHealIncrease()
    {
        if(KillCount >= healthHealPrice)
        {
            KillCount -= healthHealPrice;
            healthHealPrice += 5;
            player.GetComponent<PlayerHealth>().heal(50);
        }
    }

    public void bulletSpeedIncrease()
    {
        if(KillCount >= bulletSpeedPrice && weaponIndex != 0)
        {
            KillCount -= bulletSpeedPrice;
            bulletSpeedPrice += 10;
            bulletSpeedAdded += 1f;
        }
    }

    public void bulletDamageIncrease()
    {
        if(KillCount >= bulletDamagePrice)
        {
            KillCount -= bulletDamagePrice;
            bulletDamagePrice += 10;
            bulletDamageAdded += 5f;
        }
    }

    public void fireRateIncrease()
    {
        if(KillCount >= fireRatePrice)
        {
            KillCount -= fireRatePrice;
            fireRatePrice += 10;
            ShotSpeedMultiplier *= 0.9f;
        }
    }

    public void keyDropIncrease()
    {
        if(KillCount >= keyDropPrice)
        {
            KillCount -= keyDropPrice;
            keyDropPrice += 10;
            keyDropChance *= 2;
        }
    }

    public void weaponNextIncrease()
    {
        if(KillCount >= weaponNextPrice)
        {
            KillCount -= weaponNextPrice;
            weaponNextPrice += 50;        
            weaponIndex++;
            playerInventory.PickUpWeapon(weapons[weaponIndex]);
            if(weaponIndex >= weapons.Length - 1)
            {
                weaponNextPrice = 1000000;
            }
        }
    }

    public void AddKill()
    {
        KillCount++;
    }
}
