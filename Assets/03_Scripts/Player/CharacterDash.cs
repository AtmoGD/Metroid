using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterState
{
    Vector2 dashDirection = Vector2.zero;

    public CharacterDash(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Dashing Enter");

        Controller.RemoveDash();

        Controller.InputData.dash = false;

        Controller.MovementController.UseBaseGravity = false;

        // dashDirection.x = Controller.RigidBody.velocity.x > 0 ? 1 : -1;
        dashDirection = GetDashDirection();
    }

    public override void Exit()
    {
        base.Exit();

        Controller.MovementController.UseBaseGravity = true;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (TimeInState > Controller.Stats.dashTime)
        {
            if (Controller.IsGrounded)
            {
                if (Controller.MoveDir > Controller.Settings.idleToMoveThreshold)
                {
                    Controller.ChangeState(Controller.MoveState);
                    return;
                }
                else
                {
                    Controller.ChangeState(Controller.IdleState);
                    return;
                }
            }
            else
            {
                Controller.ChangeState(Controller.FallState);
                return;
            }
        }

        Controller.Dash(TimeInState, dashDirection);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public Vector2 GetDashDirection()
    {
        Vector2 dir = Controller.InputData.move;

        if (dir.magnitude <= 0f) return Vector2.zero;

        if (Controller.Stats.continiousDashing)
        {
            return dir.normalized;
        }
        else
        {
            return Utils.GetDirectionClamped(dir, Controller.Stats.directionType, Controller.Stats.dirThreshold);
            // if (Controller.Stats.directionType == DirectionType.Four)
            // {

            //     if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            //     {
            //         return dir.x > 0f ? Vector2.right : Vector2.left;
            //     }
            //     else
            //     {
            //         return dir.y > 0f ? Vector2.up : Vector2.down;
            //     }
            // }
            // else if (Controller.Stats.directionType == DirectionType.Eight)
            // {
            //     Vector2 dir8 = Vector2.zero;
            //     dir8.x = Mathf.Abs(dir.x) > Controller.Stats.dirThreshold ? dir.x > 0f ? 1 : -1 : 0f;
            //     dir8.y = Mathf.Abs(dir.y) > Controller.Stats.dirThreshold ? dir.y > 0f ? 1 : -1 : 0f;
            //     return dir8;
            // }
            // else if (Controller.Stats.directionType == DirectionType.Vertical)
            // {
            //     float dirY = Mathf.Abs(dir.y) > Controller.Stats.dirThreshold ? dir.y > 0f ? 1 : -1 : 0f;
            //     return new Vector2(0f, dirY);
            // }
            // else if (Controller.Stats.directionType == DirectionType.Horizontal)
            // {
            //     float dirX = Mathf.Abs(dir.x) > Controller.Stats.dirThreshold ? dir.x > 0f ? 1 : -1 : 0f;
            //     return new Vector2(dirX, 0f);
            // }
            // else
            // {
            //     return Vector2.zero;
            // }
        }
    }
}
