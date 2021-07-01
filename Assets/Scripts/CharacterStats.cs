using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Power, power, "Power"),
            new BaseStat(BaseStat.BaseStatType.Toughness, toughness, "Toughness"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "Attack Speed")
        };
    }

    public BaseStat GetStat( BaseStat.BaseStatType statType)
    {
        return stats.Find(x => x.StatType == statType);
    }

    public void AddStatBonus(List<BaseStat> baseStats)
    {
        foreach (BaseStat baseStat in baseStats)
        {
            GetStat(baseStat.StatType).AddStatBonus(new StatBonus(baseStat.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> baseStats)
    {
        foreach (BaseStat baseStat in baseStats)
        {
            GetStat(baseStat.StatType).RemoveStatBonus(baseStat.BaseValue);
        }
    }
}
