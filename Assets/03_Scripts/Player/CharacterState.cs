using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    protected CharacterController Controller { get; private set; } = null;
    protected float TimeInState { get; private set; } = 0.0f;
    protected bool CanGetHit { get; set; } = true;

    public CharacterState(CharacterController controller)
    {
        Controller = controller;
    }

    public virtual void Enter()
    {
        TimeInState = 0.0f;
    }
    public virtual void Exit() { }
    public virtual void FrameUpdate()
    {
        TimeInState += Time.deltaTime;
    }
    public virtual void PhysicsUpdate() { }
}
