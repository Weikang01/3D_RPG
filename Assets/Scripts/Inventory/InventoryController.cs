using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController instance { get; set; }
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryDetailsPanel;
    public List<Item> playerItems = new List<Item>();

    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        GiveItem("sword");
        GiveItem("staff");
        GiveItem("potion_log");
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.instance.GetItem(itemSlug);
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void GiveItem(Item item)
    {
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}
