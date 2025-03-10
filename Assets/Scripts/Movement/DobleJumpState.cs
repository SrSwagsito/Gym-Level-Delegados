using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleJumpState : BaseState
{
    public DobleJumpState(MovementController controllerController) : base(controllerController)
    {
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
