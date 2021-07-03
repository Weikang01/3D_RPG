using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int EnemyID { get; set; }

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        EnemyID = enemyID;
        Description = description;
        Completed = completed;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        if (enemy.ID == EnemyID)
        {
            CurrentAmount++;
            Debug.Log("enemy id: " + EnemyID.ToString() + " killed. " + (RequiredAmount - CurrentAmount).ToString() + " rest.");
            Evaluate();
        }
    }
}
