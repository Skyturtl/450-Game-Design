using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public GameObject weaponPrefab;
    public string playerTag = "Player";
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if(playerInventory != null)
            {
                playerInventory.PickUpWeapon(weaponPrefab);
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
