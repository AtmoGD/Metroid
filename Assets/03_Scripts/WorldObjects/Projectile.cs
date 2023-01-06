using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private bool immune = true;
    [SerializeField] private bool immuneOnStart = true;
    [SerializeField] private float immuneOnStartDelay = 0.1f;

    private float lifeTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (immuneOnStart)
            immune = true;
    }

    void Update()
    {
        if (immuneOnStart && lifeTimer >= immuneOnStartDelay)
            immune = false;

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject)
            return;

        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
            Die();
        }

        if (!immune)
            Die();
    }
}
