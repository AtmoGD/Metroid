using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : CharacterState
{
    public CharacterJump(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Controller.RemoveJump();

        Debug.Log("Jump Enter");
    }

    public override void Exit()
    {
        base.Exit();

        Controller.InputData.jump = false;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (TimeInState > Controller.Settings.minimumJumpTime)
        {

            if (Controller.IsGrounded)
            {
                Controller.ChangeState(Controller.IdleState);
                return;
            }

            if (TimeInState > Controller.Stats.jumpTime)
            {
                Controller.ChangeState(Controller.FallState);
                return;
            }

            if (!Controller.InputData.jump)
            {
                Controller.ChangeState(Controller.FallState);
                return;
            }

            if (Controller.InputData.attack && Controller.CanAttack)
            {
                Controller.ChangeState(Controller.AttackState);
                return;
            }
        }

        Controller.Jump(TimeInState);
        Controller.MoveHorizontal(TimeInState);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
