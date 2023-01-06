using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : HealthController
{
    private CharacterController characterController;

    private float immuneTime = 0.0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (immuneTime > 0.0f)
            immuneTime -= Time.deltaTime;
    }

    public override void TakeDamage(Damage damage)
    {
        if (immuneTime > 0.0f)
            return;

        base.TakeDamage(damage);

        if (characterController)
        {
            // Vector2 force = ((Vector2)transform.position - damage.HitPoint).normalized;
            // force *= damage.Force;

            characterController.OnGetHit(damage);

            immuneTime = characterController.Stats.immuneTime;
        }
    }
}
