using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : CharacterState
{
    public CharacterMove(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Controller.ResetJumps();

        Debug.Log("Move Enter");
    }

    public override void Exit()
    {
        base.Exit();

        Controller.MovementController.SetHorizontalVelocity(0.0f);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (Controller.MoveDir < Controller.Settings.idleToMoveThreshold)
        {
            Controller.ChangeState(Controller.IdleState);
            return;
        }

        if (Controller.InputData.jump && Controller.CanJump)
        {
            Controller.ChangeState(Controller.JumpState);
            return;
        }

        if (!Controller.IsGrounded)
        {
            Controller.ChangeState(Controller.FallState);
            return;
        }

        Controller.MoveHorizontal(TimeInState);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
