using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Health Potion", menuName = "Items/Health Potion")]
public class HealthPotion : Item
{
    public int healAmount = 20;

    public void Use(PlayerHealth playerHealth)
    {
        playerHealth.heal(healAmount);
    }

}
