using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int Amount { get; private set; } = 0;
    public Vector2 HitPoint { get; private set; } = Vector2.zero;
    public float Force { get; private set; } = 0.0f;

    public Damage(int amount = 0, Vector2 hitPoint = default, float force = 0.0f)
    {
        Amount = amount;
        HitPoint = hitPoint;
        Force = force;
    }

    public void SetAmount(int amount)
    {
        Amount = amount;
    }

    public void SetHitPoint(Vector2 hitPoint)
    {
        HitPoint = hitPoint;
    }

    public void SetForce(float force)
    {
        Force = force;
    }
}
