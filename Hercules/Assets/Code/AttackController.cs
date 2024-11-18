using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private MeleeWeapon meleeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAttack()
    {
        if(meleeWeapon != null)
        {
            meleeWeapon.startAttack();
        }
    }

    public void EndAttack()
    {
        if(meleeWeapon != null)
        {
            meleeWeapon.endAttack();
        }
    }

    public bool isMelee()
    {
        return meleeWeapon != null;
    }
}
