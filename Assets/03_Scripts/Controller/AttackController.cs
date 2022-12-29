using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Vector2 checkPoint = Vector2.zero;
    [SerializeField] private float checkSize = 1f;
    [SerializeField] private int comboCount = 3;
    [SerializeField] private float comboCooldown = 0.5f;

    public CharacterController Controller;
    private int attackCount = 0;

    private float attackCooldown = 0f;
    public bool CanAttack
    {
        get
        {
            // return attackCooldown <= 0f;
            return attackCooldown <= 0f;
        }
    }

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        attackCount++;

        Vector3 pos = (Vector3)checkPoint;
        pos.x *= Controller.RigidBody.velocity.x > 0 ? 1 : -1;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + pos, checkSize);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == gameObject)
                continue;

            // Check here if we hit something with a Damageable component
        }

        if (attackCount >= comboCount)
        {
            attackCount = 0;
            attackCooldown = comboCooldown;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 pos = (Vector3)checkPoint;
        if (Controller != null)
        {
            pos.x *= Controller.RigidBody.velocity.x > 0 ? 1 : -1;
        }
        Gizmos.DrawWireSphere(transform.position + pos, checkSize);
    }
}
