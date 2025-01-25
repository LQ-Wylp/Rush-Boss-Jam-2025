using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100; // Points de vie maximum
    public int currentHealth;   // Points de vie actuels
    public UnityEvent dieEvent;

    void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Assure que la vie reste entre 0 et maxHealth

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Assure que la vie ne dépasse pas maxHealth
    }

    private void Die()
    {
        dieEvent.Invoke();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
