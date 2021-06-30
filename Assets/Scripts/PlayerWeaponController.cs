using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    IWeapon _equippedWeapon;
    CharacterStat characterStat;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        spawnProjectile = transform.FindChild("ProjectileSpawn");
#pragma warning restore CS0618 // Type or member is obsolete
        characterStat = GetComponent<CharacterStat>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            characterStat.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        _equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;

        _equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStat.AddStatBonus(itemToEquip.Stats);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformWeaponAttack();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
        {
            PerformWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        _equippedWeapon.PerformAttack();
    }

    public void PerformWeaponSpecialAttack()
    {
        _equippedWeapon.PerformSpecialAttack();
    }
}
