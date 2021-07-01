using System.Collections;
using System.Collections.Generic;

public interface IWeapon
{
    List<BaseStat> Stats { get; set; }
    CharacterStats characterStats { get; set; }
    void PerformAttack();
    void PerformSpecialAttack();
}
