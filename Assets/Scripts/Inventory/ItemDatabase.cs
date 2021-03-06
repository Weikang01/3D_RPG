using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance { get; set; }
    private List<Item> items { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/items").ToString());
    }

    public Item GetItem(string itemSlug)
    {
        foreach (Item item in items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.LogWarning("Couldn't find item: " + itemSlug);
        return null;
    }
}
