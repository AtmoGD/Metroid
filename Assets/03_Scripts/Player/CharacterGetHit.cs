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

        Debug.Log("Get Hit Enter");

        Controller.InputData.move = Vector2.zero;

        Controller.RigidBody.velocity = Vector2.zero;

        CanGetHit = false;

        Controller.ApplyHitForce();
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
            Controller.ChangeState(Controller.FallState);
            return;
        }
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
