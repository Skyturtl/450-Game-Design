using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private Controller script;

    public void Start()
    {
        script = GetComponent<Controller>();
        InvokeRepeating("FireProjectile", 0f, 0.25f); //https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
    }

    //Shoot called every half-second
    void FireProjectile()
    {
        GameObject newProjectile = Instantiate(script.projectilePrefab);
        Vector3 offset = script.aimPivot.right * 0.5f; // Adjust the offset distance as needed
        newProjectile.transform.position = script.transform.position + offset;
        newProjectile.transform.rotation = script.aimPivot.rotation;
    }
}
