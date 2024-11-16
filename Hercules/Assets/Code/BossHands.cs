using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHands : MonoBehaviour
{

    public float lifetime;

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
}
