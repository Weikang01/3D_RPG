using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int Experience { get; set; }
    void Die();
    void TakeDamage(int amount);
    void EnemyPerformAttack();
}
