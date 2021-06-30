using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { Weapon, Consumable, Quest}
    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes itemType { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }


    public Item(List<BaseStat> _stats, string _objectSlug)
    {
        this.Stats = _stats;
        this.ObjectSlug = _objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _stats, string _objectSlug, string _description, ItemTypes _itemType, string _actionName, string _itemName, bool _itemModifier)
    {
        this.Stats = _stats;
        this.ObjectSlug = _objectSlug;
        this.Description = _description;
        this.itemType = _itemType;
        this.ActionName = _actionName;
        this.ItemName = _itemName;
        this.ItemModifier = _itemModifier;
    }
}
