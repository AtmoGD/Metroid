using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1f;

    [SerializeField] private float lerpSpeed = 1f;

    [SerializeField] private float baseGravity = -0.1f;

    public bool UseBaseGravity { get; set; } = true;

    private Rigidbody2D rb = null;
    private Vector2 targetVelocity = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    public void Move(Vector2 _velocity)
    {
        targetVelocity = _velocity;
    }

    private void FixedUpdate()
    {
        // rb.MovePosition(rb.position + velocity * Time.deltaTime);
        // rb.velocity = targetVelocity * Time.deltaTime;
    }

    private void Update()
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity = Vector2.Lerp(newVelocity, targetVelocity, lerpSpeed * Time.deltaTime);

        if (UseBaseGravity)
            newVelocity.y += baseGravity * Time.deltaTime;

        rb.velocity = newVelocity;
    }

    public void AddVelocity(Vector2 _velocity)
    {
        targetVelocity += _velocity;
    }

    public void AddVerticalVelocity(float _velocity)
    {
        targetVelocity.y += _velocity;
    }

    public void AddHorizontalVelocity(float _velocity)
    {
        targetVelocity.x += _velocity;
    }

    public void AddHorizontalVelocityClamped(float _velocity)
    {
        targetVelocity.x += _velocity;

        targetVelocity.x = Mathf.Clamp(targetVelocity.x, -maxSpeed, maxSpeed);
    }

    public void SetVelocity(Vector2 _velocity, bool _lerp = false)
    {
        targetVelocity = _velocity;
    }

    public void SetVerticalVelocity(float _velocity)
    {
        targetVelocity.y = _velocity;
    }

    public void SetHorizontalVelocity(float _velocity)
    {
        targetVelocity.x = _velocity;
    }

    public void SetHorizontalVelocityClamped(float _velocity)
    {
        SetHorizontalVelocity(Mathf.Clamp(_velocity, -maxSpeed, maxSpeed));
    }
}
