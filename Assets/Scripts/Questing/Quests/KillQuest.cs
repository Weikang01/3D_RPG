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

        Goals.Add(new KillGoal(this, 0, "Kill 1 Slimes", false, 0, 2));
        Goals.Add(new KillGoal(this, 1, "Kill 1 Vampires", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
