using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int currentHealth;
    public int maxHealth;

    private void Start()
    {
        this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(10, 10, 10);
        UIEventHandler.PlayerHealthChanged(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
        UIEventHandler.PlayerHealthChanged(currentHealth, maxHealth);
    }

    void Die()
    {
        Debug.Log("Player dead. Reset health.");
        this.currentHealth = this.maxHealth;
        UIEventHandler.PlayerHealthChanged(currentHealth, maxHealth);
    }
}
