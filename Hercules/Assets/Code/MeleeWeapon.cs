using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Upgrade upgrade;
    private float adjustedDamage;
    private float adjustedSwingSpeed;
    public float damage = 10f;
    public float swingSpeed;
    private HashSet<GameObject> damagedEnemies = new HashSet<GameObject>();
    private bool isAttacking = false;
    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        animator.SetFloat("AttackSpeed", swingSpeed);
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
    }

    public void Update()
    {
        adjustedDamage = damage + upgrade.bulletDamageAdded;
        adjustedSwingSpeed = swingSpeed / upgrade.ShotSpeedMultiplier;
        animator.SetFloat("AttackSpeed", adjustedSwingSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isAttacking)
        {
            if (!damagedEnemies.Contains(collision.gameObject))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage, gameObject);
                    //SoundManager.instance.PlaySwordSwing();
                    damagedEnemies.Add(collision.gameObject);
                }
            }
        }
            
    }

    public void startAttack()
    {
        isAttacking = true;
        damagedEnemies.Clear();
    }

    public void endAttack()
    {
        isAttacking = false;
    }
}
