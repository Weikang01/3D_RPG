using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ItemSlug { get; set; }

    public CollectionGoal(Quest quest, string itemSlug, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        ItemSlug = itemSlug;
        Description = description;
        Completed = completed;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToInventory += ItemPickedUp;
    }

    void ItemPickedUp(Item item)
    {
        Debug.Log(item.ObjectSlug + " awd " + ItemSlug + " awdawd " + (item.ObjectSlug == ItemSlug).ToString());
        if (item.ObjectSlug == ItemSlug)
        {
            CurrentAmount++;
            Debug.Log("item name: " + ItemSlug + " . " + (RequiredAmount - CurrentAmount).ToString() + " rest.");
            Evaluate();
        }
    }
}
