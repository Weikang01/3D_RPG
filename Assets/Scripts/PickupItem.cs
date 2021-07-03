using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item ItemDrop { get; set; }

    public override void Interact()
    {
        InventoryController.instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }
}
