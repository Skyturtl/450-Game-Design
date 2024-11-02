using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    private Transform target;
    public float NewAggroDistance;
    private Enemy script;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        script = GetComponent<Enemy>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        renderer.material.color = new Color(1f, 1f, 1f, 0.05f);
        if (distance <= NewAggroDistance)
        {
            renderer.material.color = Color.white;
        }
    }
}
