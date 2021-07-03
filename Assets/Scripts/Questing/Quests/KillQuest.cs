using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    private void Start()
    {
        QuestName = "Kill Quest";
        Description = "Kill a bunch of stuff.";
        ItemReward = ItemDatabase.instance.GetItem("potion_log");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(0, "Kill 5 Slimes", false, 0, 5));
        Goals.Add(new KillGoal(1, "Kill 2 Vampires", false, 0, 2));

        Goals.ForEach(g => g.Init());
    }
}
