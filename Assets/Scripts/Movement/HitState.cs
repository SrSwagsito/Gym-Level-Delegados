using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : BaseState
{
    public HitState(MovementController controllerController) : base(controllerController)
    {
        controller.anim.Play("Hit");
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
