using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;
    //public Image healthBar;

    //hide sprite rather than destroy object
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 1);        
    }

    public void takeDamage(float damage){
        playerHealth -= damage;
        if(playerHealth <= 0){
            //Destroy(gameObject);

            //hide the sprite
            sprite.enabled = false;
            //disable projectile script
            gameObject.GetComponent<Controller>().enabled = false;
            //prompt game over
        }
    }
}
