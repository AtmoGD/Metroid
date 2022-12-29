using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool _debug = false;

    public MovementController MovementController { get; private set; } = null;
    public AttackController AttackController { get; private set; } = null;
    public Rigidbody2D RigidBody { get; private set; } = null;
    public Animator Animator { get; private set; } = null;

    private CharacterState CurrentState { get; set; } = null;
    public CharacterIdle IdleState { get; private set; } = null;
    public CharacterMove MoveState { get; private set; } = null;
    public CharacterStopMovement StopMovementState { get; private set; } = null;
    public CharacterJump JumpState { get; private set; } = null;
    public CharacterFall FallState { get; private set; } = null;
    public CharacterAttack AttackState { get; private set; } = null;

    [Header("References")]
    [SerializeField] private Transform _groundCheck = null;
    public Transform GroundCheck => _groundCheck;


    [Header("Settings")]
    [SerializeField] public CharacterSettings _settings = null;
    public CharacterSettings Settings => _settings;

    [SerializeField] public CharacterStats _stats = null;
    public CharacterStats Stats => _stats;

    [Header("Upgrades")]
    [SerializeField] private float jumpHeightMultiplier = 1f;
    public float JumpHeightMultiplier => jumpHeightMultiplier;



    [Header("Just for debbing exposed")]
    [SerializeField] private CharacterInput _inputData = null;
    public CharacterInput InputData => _inputData;

    [SerializeField] private int _jumpsLeft = 0;
    public int JumpsLeft => _jumpsLeft;
    public bool CanJump => JumpsLeft > 0;

    public bool IsGrounded
    {
        get
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(GroundCheck.position, Settings.groundCheckSize, 0f, Settings.groundMask);
            return colliders.Length > 0;
        }
    }

    public float MoveDir
    {
        get
        {
            return Mathf.Abs(InputData.move);
        }
    }


    private void Awake()
    {
        MovementController = GetComponent<MovementController>();
        AttackController = GetComponent<AttackController>();

        RigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        IdleState = new CharacterIdle(this);
        MoveState = new CharacterMove(this);
        StopMovementState = new CharacterStopMovement(this);
        JumpState = new CharacterJump(this);
        FallState = new CharacterFall(this);
        AttackState = new CharacterAttack(this);
    }

    private void Start()
    {
        ChangeState(FallState);
    }

    private void Update()
    {
        CurrentState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    public void ChangeState(CharacterState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputData.SetMove(context.ReadValue<Vector2>().x);
    }

    public void MoveHorizontal(float _time)
    {
        float newVelocityX = InputData.move * Stats.accelerationCurve.Evaluate(_time);
        MovementController.SetHorizontalVelocityClamped(newVelocityX);
    }

    public void MoveAttack(float _time)
    {
        float dir = RigidBody.velocity.x > 0 ? 1 : -1;

        float newVelocityX = Stats.attackXCurve.Evaluate(_time) * dir;
        MovementController.SetHorizontalVelocityClamped(newVelocityX);

        float newVelocityY = Stats.attackYCurve.Evaluate(_time);
        MovementController.SetVerticalVelocity(newVelocityY);
    }

    public void StopMove(float _time, float _startVelocity)
    {
        float newVelocityX = _startVelocity * InputData.move * Stats.decelerationCurve.Evaluate(_time);
        MovementController.SetHorizontalVelocityClamped(newVelocityX);
    }

    public void Fall(float _time)
    {
        float newYVelocity = Stats.fallCurve.Evaluate(_time);

        MovementController.SetVerticalVelocity(newYVelocity);
    }

    public void Jump(float _time)
    {
        float time = _time / Stats.jumpTime;

        float newYVelocity = Stats.jumpCurve.Evaluate(time) * Stats.jumpHeight;
        MovementController.SetVerticalVelocity(newYVelocity);
    }

    public void RemoveJump()
    {
        _jumpsLeft--;
    }

    public void AddJump(int _amount = 1)
    {
        _jumpsLeft += _amount;
    }

    public void ResetJumps()
    {
        _jumpsLeft = Stats.maxJumps;
    }

    public void OnJump(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            InputData.SetJump(true);
        }
        else if (_context.canceled)
        {
            InputData.SetJump(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            InputData.SetAttack(true);
        }
        else if (_context.canceled)
        {
            InputData.SetAttack(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (_debug)
        {
            if (IsGrounded)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;

            Gizmos.DrawWireCube(_groundCheck.position, _settings.groundCheckSize);

            // Draw an arrow to show the length and direction of the movement

            if (RigidBody)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(transform.position, RigidBody.velocity);
            }
        }
    }
}