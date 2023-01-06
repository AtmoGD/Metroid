using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(int damage, GameObject damageSource, float damageForce);
    int CurrentHealth { get; }
    int MaxHealth { get; }
}
