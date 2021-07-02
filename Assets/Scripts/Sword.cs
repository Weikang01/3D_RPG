using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStats characterStats { get; set; }
    public int CurrentDamage { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("BaseAttack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("SpecialAttack");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }

    public void CastProjectile()
    {
    }
}
