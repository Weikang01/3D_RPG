using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;
    public Quest quest { get; set; }

    public override void Interact()
    {
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if (!Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue("Thanks for that stuff that one time.", Name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (quest.Completed)
        {
            quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue("Thanks for that!", Name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue("You're still in the middle of helping me.", Name);
        }
    }
}
