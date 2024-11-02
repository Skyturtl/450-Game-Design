using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{

    private Transform target;
    public float NewAggroDistance;
    private Enemy script;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        script = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= NewAggroDistance)
        {
            script.ChaseSpeed = 20;
        }
    }
}
