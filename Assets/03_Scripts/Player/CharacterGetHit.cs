using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGetHit : CharacterState
{
    public CharacterGetHit(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanGetHit = false;
    }

    public override void Exit()
    {
        base.Exit();

        CanGetHit = true;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (TimeInState >= Controller.Stats.getHitTime)
        {
            Controller.ChangeState(Controller.IdleState);
            return;
        }

        Controller.MoveHitForce();
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
