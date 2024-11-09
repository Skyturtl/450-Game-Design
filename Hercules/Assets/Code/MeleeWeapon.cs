using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Upgrade upgrade;
    public float damage;
    public float swingSpeed;
    private HashSet<GameObject> damagedEnemies = new HashSet<GameObject>();
    private bool isAttacking = false;
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
        if (collision.CompareTag("Enemy") && isAttacking)
        {
            if (!damagedEnemies.Contains(collision.gameObject))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage, gameObject);
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
