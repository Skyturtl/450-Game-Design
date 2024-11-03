using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject currentWeapon;
    public Transform aimPivot;

    public void PickUpWeapon(GameObject weaponPrefab)
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        
        currentWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        currentWeapon.transform.SetParent(transform);
        Shoot weaponShooting = currentWeapon.GetComponentInChildren<Shoot>();
        if (weaponShooting != null && aimPivot != null)
        {
            Debug.Log("AimPivot set");
            weaponShooting.SetAimPivot(aimPivot);
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
