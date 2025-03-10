using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{

    public JumpState(MovementController controllerController) : base(controllerController)
    {
        
    }

    public override void StartState()
    {
        controller.anim.CrossFade("Jump", 0.1f);
    }
    public override void UpdateState()
    {
            if (controller.isGrounded && controller.rigid.velocity.y <= 0)
        {
            //Exit to Jump
            if (controller.horizontal == 0)
            {
                ExitState(controller.idle);
            }

            //Exit to Walk
            else if (controller.horizontal != 0)
            {
                ExitState(controller.walk);
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
