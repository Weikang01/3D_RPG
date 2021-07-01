using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStats characterStats { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
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
            col.gameObject.GetComponent<IEnemy>().TakeDamage(characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue());
        }
    }

    public void CastProjectile()
    {
    }
}
