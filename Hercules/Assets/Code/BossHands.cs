using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHands : MonoBehaviour
{

    public float lifetime;
    public float damage;

    private float timeElapsed;

    //DoT
    public float damageInterval;
    public float onContactDamage;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed > lifetime)
        {
            Destroy(gameObject);
        }

        timeElapsed += Time.deltaTime;
    }

    //deal damage as long as the player continues to collide with the hand
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timePassed += Time.deltaTime;
            if (timePassed >= damageInterval)
            {
                other.gameObject.GetComponent<PlayerHealth>().takeDamage(onContactDamage, gameObject);
                timePassed = 0;
                Debug.Log("DoT");
            }
        }
    }
}
