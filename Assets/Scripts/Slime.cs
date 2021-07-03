using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{

    public LayerMask aggroLayerMask;
    private NavMeshAgent navAgent;
    public int maxHealth;
    public int currentHealth;

    private Player player;

    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    public int Experience { get; set; }

    private void Start()
    {
        Experience = 30;
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(6, 10, 2);
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if (withinAggroColliders.Length != 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    void ChasePlayer(Player player)
    {
        this.player = player;
        navAgent.SetDestination(player.transform.position);
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("EnemyPerformAttack"))
                InvokeRepeating("EnemyPerformAttack", .5f, 2f);
        }
        else
        {
            CancelInvoke("EnemyPerformAttack");
        }
    }

    public void EnemyPerformAttack()
    {
        player.TakeDamage(5);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        Destroy(gameObject);
    }
}
