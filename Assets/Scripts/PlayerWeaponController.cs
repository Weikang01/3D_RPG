using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    IWeapon _equippedWeapon;
    CharacterStats characterStats;
    Item currentlyEquippedItem;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        spawnProjectile = transform.FindChild("ProjectileSpawn");
#pragma warning restore CS0618 // Type or member is obsolete
        characterStats = GetComponent<Player>().characterStats;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            UnequipWeapon();
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        _equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;

        EquippedWeapon.transform.SetParent(playerHand.transform);
        _equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        characterStats.AddStatBonus(itemToEquip.Stats);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        if (EquippedWeapon != null)
        {
            InventoryController.instance.GiveItem(currentlyEquippedItem.ObjectSlug);
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PerformWeaponAttack();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            PerformWeaponAttack();
    }

    public void PerformWeaponAttack()
    {
        _equippedWeapon.PerformAttack(CalculateDamage());
    }

    public void PerformWeaponSpecialAttack()
    {
        _equippedWeapon.PerformSpecialAttack();
    }

    private int CalculateDamage()
    {
        int damage = characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue();
        damage += CalculateCrit(damage);
        Debug.Log(damage);
        return damage;
    }

    private int CalculateCrit(int damage)
    {
        if (Random.value <= .2f)
            return damage + (int)(damage * Random.Range(.24f, .5f));
        else
            return 0;
    }
}
