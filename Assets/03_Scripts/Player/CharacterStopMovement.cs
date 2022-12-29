using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStopMovement : CharacterState
{
    float startVelocity = 0f;
    public CharacterStopMovement(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        startVelocity = Controller.RigidBody.velocity.x;

        Debug.Log("Stop Enter Enter");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (Controller.MoveDir > Controller.Settings.idleToMoveThreshold)
        {
            Controller.ChangeState(Controller.MoveState);
            return;
        }

        if (Controller.InputData.jump && Controller.CanJump)
        {
            Controller.ChangeState(Controller.JumpState);
            return;
        }

        Controller.StopMove(TimeInState, startVelocity);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
