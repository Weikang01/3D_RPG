using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level."));
        stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
    }

    public void AddStatBonus(List<BaseStat> baseStats)
    {
        foreach (BaseStat baseStat in baseStats)
        {
            stats.Find(x => x.StatName == baseStat.StatName).AddStatBonus(new StatBonus(baseStat.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> baseStats)
    {
        foreach (BaseStat baseStat in baseStats)
        {
            stats.Find(x => x.StatName == baseStat.StatName).RemoveStatBonus(baseStat.BaseValue);
        }
    }
}
