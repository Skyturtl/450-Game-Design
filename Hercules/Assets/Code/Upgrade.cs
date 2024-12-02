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
    // UI
    public TMP_Text killsText;
    public Button meleeLeft;
    public Button meleeRight;
    public Button meleeMiddle;

    // prices
    private int pDamagePrice = 5;
    private int pSpeedPrice = 3;
    private int healthPrice = 5;
    private int speedPrice = 10;
    private int mDamagePrice = 10;
    private int mCooldownPrice = 10;
    private int keyDropPrice = 10;
    private int mPrice = 25;

    // Events
    public delegate void UpgradeEventHandler();
    public event UpgradeEventHandler pDamageUpgrade;
    public event UpgradeEventHandler pSpeedUpgrade;
    public event UpgradeEventHandler healthUpgrade;
    public event UpgradeEventHandler healthHeal;
    public event UpgradeEventHandler speedUpgrade;
    public event UpgradeEventHandler mPurchase;
    public event UpgradeEventHandler mDamageUpgrade;
    public event UpgradeEventHandler mCooldownUpgrade;
    public event UpgradeEventHandler keyDropUpgrade;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    void Update(){
        killsText.text = "Kills: " + KillCount;
    }

    public void damageIncrease()
    {
        if(KillCount >= pDamagePrice)
        {
            pDamageUpgrade?.Invoke();
            KillCount -= pDamagePrice;
        }
        pDamagePrice += 5;
    }

    public void speedIncrease()
    {
        if(KillCount >= pSpeedPrice)
        {
            pSpeedUpgrade?.Invoke();
            KillCount -= pSpeedPrice;
        }
        pSpeedPrice += 3;
    }

    public void healthIncrease()
    {
        if(KillCount >= healthPrice)
        {
            healthUpgrade?.Invoke();
            KillCount -= healthPrice;
        }
        healthPrice += 5;
    }

    public void heal()
    {
        if(KillCount >= healthPrice)
        {
            healthHeal?.Invoke();
            KillCount -= healthPrice;
        }
        healthPrice += 5;
    }

    public void speedIncreasePlayer()
    {
        if(KillCount >= speedPrice)
        {
            speedUpgrade?.Invoke();
            KillCount -= speedPrice;
        }
        speedPrice += 10;
    }

    public void mDamageIncrease()
    {
        if(KillCount >= mDamagePrice)
        {
            mDamageUpgrade?.Invoke();
            KillCount -= mDamagePrice;
        }
        mDamagePrice += 10;
    }

    public void mCooldownIncrease()
    {
        if(KillCount >= mCooldownPrice)
        {
            mCooldownUpgrade?.Invoke();
            KillCount -= mCooldownPrice;
        }
        mCooldownPrice += 10;
    }
    
    public void keyDropIncrease()
    {
        if(KillCount >= keyDropPrice)
        {
            keyDropUpgrade?.Invoke();
            KillCount -= keyDropPrice;
        }
        keyDropPrice += 10;
    }

    public void mBuy()
    {
        if(KillCount >= mPrice)
        {
            mPurchase?.Invoke();
            KillCount -= mPrice;
        }
        meleeLeft.transform.position += new Vector3(0, 0, 0);
        meleeRight.transform.position += new Vector3(0, 0, 0);
        meleeMiddle.enabled = false;
    }
        
    public void AddKill()
    {
        KillCount++;
    }
}
