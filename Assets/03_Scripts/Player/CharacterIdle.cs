using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdle : CharacterState
{
    public CharacterIdle(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Controller.ResetJumps();
        Controller.ResetDashes();

        Controller.MovementController.SetVelocity(Vector2.zero);

        Debug.Log("Idle Enter");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (!Controller.IsGrounded)
        {
            Controller.ChangeState(Controller.FallState);
            return;
        }

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


        if (Controller.InputData.attack && Controller.AttackController.CanAttack)
        {
            Controller.ChangeState(Controller.AttackState);
            return;
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
