using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;
    public Text itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();
    }

    void SetupItemValues()
    {
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
    }

    public void OnSelectItemButton()
    {
        InventoryController.instance.SetItemDetails(item, GetComponent<Button>());
    }
}
