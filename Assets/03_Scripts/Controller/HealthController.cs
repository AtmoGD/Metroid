using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamagable
{
    [SerializeField] protected int maxHealth = 3;
    [SerializeField] protected int currentHealth = 3;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public virtual void TakeDamage(int damage, GameObject damageSource, float damageForce)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}