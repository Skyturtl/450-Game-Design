using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform aimPivot;
    public GameObject projectilePrefab;
    private float adjustedShotSpeed;
    private float adjustedSwingSpeed;
    public float shotSpeed;
    public Upgrade upgrade;
    private Animator animator;
    private float timePassed;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
        animator.SetFloat("AttackSpeed", shotSpeed);
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
    }

    public void Update()
    {
        timePassed += Time.deltaTime;
        adjustedShotSpeed = shotSpeed * upgrade.ShotSpeedMultiplier;
        adjustedSwingSpeed = shotSpeed / upgrade.ShotSpeedMultiplier * 2;
        animator.SetFloat("AttackSpeed", adjustedSwingSpeed);
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
