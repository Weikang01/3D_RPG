using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();
    }

    void SetupItemValues()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        transform.FindChild("Item_Name").GetComponent<Text>().text = item.ItemName;
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void OnSelectItemButton()
    {
        InventoryController.instance.SetItemDetails(item, GetComponent<Button>());
    }
}
