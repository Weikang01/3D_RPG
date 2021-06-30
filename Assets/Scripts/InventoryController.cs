using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public Item sword;
    public Item potionLog;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();

        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level"));
        sword = new Item(swordStats, "staff");
        potionLog = new Item(new List<BaseStat>(), "potion_log", "Drink this to log something cool!", "Drink", "Log Posion", false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
            consumableController.ConsumeItem(potionLog);
        }
    }
}
