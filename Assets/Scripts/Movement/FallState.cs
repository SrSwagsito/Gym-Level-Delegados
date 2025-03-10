using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    public FallState(MovementController controllerController) : base(controllerController)
    {
        controller.anim.Play("Jump");
    }

    public override void StartState()
    {
    }
    public override void UpdateState()
    {
    }
    public override void FixedUpdateState()
    {
    }
    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }
}
