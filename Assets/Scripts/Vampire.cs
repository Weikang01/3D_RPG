using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Vampire : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    private NavMeshAgent navAgent;
    public int maxHealth;
    public int currentHealth;

    private Player player;

    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    public int Experience { get; set; }
    public DropTable dropTable { get; set; }
    public Spawner spawner { get; set; }
    public int ID { get; set; }

    public PickupItem pickupItem;

    private void Start()
    {
        ID = 1;
        Experience = 30;
        dropTable = new DropTable();
        dropTable.loot = new List<LootDrop>
        {
            new LootDrop("sword", 25),
            new LootDrop("staff", 25),
            new LootDrop("potion_log", 25)
        };
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
        DropLoot();
        CombatEvents.EnemyDied(this);
        this.spawner.Respawn();
        Destroy(gameObject);
    }

    void DropLoot()
    {
        Item item = dropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }
}
