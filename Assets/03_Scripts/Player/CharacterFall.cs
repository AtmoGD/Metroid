using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFall : CharacterState
{
    public CharacterFall(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Falling Enter");
    }

    public override void Exit()
    {
        base.Exit();

        Controller.MovementController.SetVerticalVelocity(0.0f);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (Controller.IsGrounded)
        {
            Controller.ChangeState(Controller.IdleState);
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

        if (Controller.InputData.dash && Controller.CanDash)
        {
            Controller.ChangeState(Controller.DashState);
            return;
        }

        if (Controller.InputData.chargeTime && Controller.CanCharge)
        {
            Controller.ChangeState(Controller.ChargeTimeState);
            return;
        }

        Controller.Fall(TimeInState);

        if (Controller.Stats.canMoveWhileFalling)
            Controller.MoveHorizontal(TimeInState);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
