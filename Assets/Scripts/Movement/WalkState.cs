using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState
{
    public WalkState(MovementController controllerController) : base(controllerController)
    {
        controller.anim.CrossFade("Walk", 0.1f);
    }

    public override void StartState()
    {
    }
    public override void UpdateState()
    {
        if (controller.isGrounded && controller.rigid.velocity.y <= 0)
        {
            //Exit to Jump
            if (Input.GetKeyDown(controller.JumpButton))
            {
                ExitState(controller.jump);
            }

            //Exit to Idle
            else if (controller.horizontal == 0)
            {
                ExitState(controller.idle);
            }
        }
    }
    public override void FixedUpdateState()
    {
    }
    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }
}
