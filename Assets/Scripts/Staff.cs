using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
    }

    public void PerformAttack()
    {

        animator.SetTrigger("BaseAttack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("SpecialAttack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
