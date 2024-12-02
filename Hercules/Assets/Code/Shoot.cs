using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform aimPivot;
    public GameObject projectilePrefab;
    public float adjustedShotSpeed;
    public float shotSpeed;
    public Upgrade upgrade;
    private Animator animator;
    private float timePassed;

    public void Start()
    {
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
        animator = GetComponentInParent<Animator>();
    }

    public void Update()
    {
        timePassed += Time.deltaTime;
        adjustedShotSpeed = shotSpeed * upgrade.ShotSpeedMultiplier;
        animator.SetFloat("AttackSpeed", adjustedShotSpeed);
        if(timePassed > adjustedShotSpeed)
        {
            FireProjectile();
            timePassed = 0;
        }
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
