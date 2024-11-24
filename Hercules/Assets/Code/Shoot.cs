using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform aimPivot;
    public GameObject projectilePrefab;
    public float shotSpeed;

    private Animator animator;
    //private Controller script;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
        animator.SetFloat("AttackSpeed", shotSpeed);
        //script = GetComponent<Controller>();
        InvokeRepeating("FireProjectile", 0.1f, 1/ shotSpeed); //https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
    }

   
    //Shoot called every half-second
    void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        Vector3 offset = aimPivot.right * 1.5f; // Adjust the offset distance as needed
        newProjectile.transform.position = transform.position + offset;
        newProjectile.transform.rotation = aimPivot.rotation;
    }

    public void SetAimPivot(Transform pivot)
    {
        aimPivot = pivot;
    }
}
