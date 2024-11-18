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
    private float damageAmount;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        animator.SetFloat("AttackSpeed", swingSpeed);
        Upgrade upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
        damageAmount = damage + upgrade.attackPower;
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
                    enemy.TakeDamage(damageAmount, gameObject);
                    SoundManager.instance.PlaySwordSwing();
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

    public void UpdateAttackPower(float newAttackPower)
    {
        damageAmount = newAttackPower + damage;
        Debug.Log("damage Amount is " + damageAmount);
    }

}
