using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChargeTime : CharacterState
{
    public float targetTime = 1f;

    public Vector2 lastAim = Vector2.zero;

    public CharacterChargeTime(CharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();

        lastAim = Vector2.zero;

        Controller.ChooseElementAnimator.SetBool("IsVisible", true);

        Debug.Log("Charging Enter");
    }

    public override void Exit()
    {
        base.Exit();

        Time.timeScale = 1f;

        Controller.targetTime = 1f;

        Controller.ChooseElementAnimator.SetBool("IsVisible", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (Controller.InputData.aim.magnitude > 0.5f)
            lastAim = Utils.GetDirectionClamped(Controller.InputData.aim, DirectionType.Four);

        Controller.ChooseElementAnimator.SetFloat("AimX", lastAim.x);
        Controller.ChooseElementAnimator.SetFloat("AimY", lastAim.y);

        Debug.Log("Charging FrameUpdate : " + lastAim);

        if (TimeInState > Controller.Stats.chargeTime)
        {
            Controller.ChangeState(Controller.FallState);
            return;
        }

        if (Controller.targetTime == 1f)
        {
            if (lastAim.magnitude < 0.5f)
            {
                Controller.Player.ChangeForm(CharacterForm.Base);
            }
            else
            {
                switch (Utils.GetDirectionFrom(lastAim))
                {
                    case Direction.Up:
                        Controller.Player.ChangeForm(CharacterForm.Fire);
                        break;
                    case Direction.Down:
                        Controller.Player.ChangeForm(CharacterForm.Air);
                        break;
                    case Direction.Left:
                        Controller.Player.ChangeForm(CharacterForm.Nature);
                        break;
                    case Direction.Right:
                        Controller.Player.ChangeForm(CharacterForm.Ice);
                        break;
                    default:
                        break;
                }
            }

            Controller.ChangeState(Controller.IdleState);
        }

        Time.timeScale = Mathf.Lerp(Time.timeScale, Controller.targetTime, Controller.Stats.chargeSpeed * Time.deltaTime);
    }



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
