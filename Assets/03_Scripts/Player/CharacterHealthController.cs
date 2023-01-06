using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : HealthController
{
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public override void TakeDamage(int damage, GameObject damageSource, float damageForce)
    {
        base.TakeDamage(damage, damageSource, damageForce);

        if (characterController)
        {
            Vector2 force = (transform.position - damageSource.transform.position).normalized;
            force *= damageForce;

            characterController.OnGetHit(force);
        }
    }
}
