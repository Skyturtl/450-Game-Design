using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Upgrade upgrade;
    public float damage;
    public float swingSpeed;

    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        animator.SetFloat("AttackSpeed", swingSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
        damage += upgrade.attackPower;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage, gameObject);
            }
        }
    }
}
