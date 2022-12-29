using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterState
{
    public CharacterAttack(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Controller.InputData.attack = false;

        Controller.MovementController.UseBaseGravity = false;

        Debug.Log("Attack Enter");
    }

    public override void Exit()
    {
        base.Exit();

        Controller.MovementController.UseBaseGravity = true;

        //TODO: Remove later -> Just while we dont have a animation which triggers "Attack" in AttackController
        Controller.AttackController.Attack();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (TimeInState > Controller.Stats.attackTime)
        {
            Controller.ChangeState(Controller.IdleState);
            return;
        }

        Controller.MoveAttack(TimeInState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
