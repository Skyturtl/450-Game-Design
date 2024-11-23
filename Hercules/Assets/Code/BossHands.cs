using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHands : MonoBehaviour
{

    public float lifetime;
    public float damage;

    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
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
            StartCoroutine(DealDamage(other));
        }
    }

    private IEnumerator DealDamage(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().takeDamage(damage, gameObject);
        yield return new WaitForSeconds(5f);
    }
}
