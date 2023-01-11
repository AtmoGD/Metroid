using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : CharacterState
{
    bool isWallJump = false;
    int wallJumpDirection = 0;

    public CharacterJump(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        bool touchingRight = Controller.IsTouchingWallRight;
        bool touchingLeft = Controller.IsTouchingWallLeft;

        isWallJump = touchingRight || touchingLeft;

        if (isWallJump)
            wallJumpDirection = touchingRight ? -1 : 1;
        else
            Controller.RemoveJump();

        Debug.Log("Jump Enter, Is Wall Jump: " + isWallJump);
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
        }

        Controller.Jump(TimeInState);

        if (isWallJump)
            Controller.WallJumpHorizontal(TimeInState, wallJumpDirection);
        else
            Controller.MoveHorizontal(TimeInState);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
