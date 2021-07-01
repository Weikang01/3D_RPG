using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractionButtonText;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        itemNameText = transform.FindChild("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.FindChild("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.FindChild("Item_Interact_Button").GetComponent<Button>();
        itemInteractionButtonText = itemInteractButton.transform.FindChild("Text").GetComponent<Text>();
        itemInteractButton.onClick.AddListener(OnItemInteract);
        gameObject.SetActive(false);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        this.item = item;
        this.selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractionButtonText.text = item.ActionName;
    }

    public void OnItemInteract()
    {
        Debug.Log(item.itemType.ToString());
        if (item.itemType == Item.ItemTypes.Consumable)
        {
            InventoryController.instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.itemType == Item.ItemTypes.Weapon)
        {
            InventoryController.instance.EquipItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        RemoveItem();
    }

    private void RemoveItem()
    {
        item = null;
        gameObject.SetActive(false);
    }
}
