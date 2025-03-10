using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(MovementController controllerController) : base(controllerController) 
    {
    }

    public override void StartState()
    {
        controller.anim.CrossFade("Idle", 0.1f);
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

            //Exit to Walk
            else if (controller.horizontal != 0)
            {
                ExitState(controller.walk);
            }
        }
    }
    public override void FixedUpdateState()
    {
        controller.rigid.velocity = new Vector2(controller.horizontal * controller.speed, controller.rigid.velocity.y);
    }
    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }
}
