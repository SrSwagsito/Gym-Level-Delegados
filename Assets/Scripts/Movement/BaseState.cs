 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public BaseState(MovementController controllerParameter) 
    {
        controller = controllerParameter;
    }

    protected MovementController controller;
    public abstract void StartState();
            
    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public abstract void ExitState(BaseState newState);
    
}
