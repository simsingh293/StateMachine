using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    // IDLE state can transition into the following states
    // RUN - ATTACK - DODGE - STUNNED
        // add more as we create them


    StateManager stateManager;


    public IdleState(StateManager state) : base(state.gameObject)
    {
        stateManager = state;
    }

    public override Type Tick()
    {
        Debug.Log("Idle");
        //DetectAction();
        if (stateManager._Zinp)
        {
            Debug.Log("test");
            return typeof(RunState);
        }

        return null;
    }

    Type DetectAction()
    {
        if (stateManager._Zinp)
        {
            return typeof(RunState);
        }
        else
        {
            return null;
        }
    }
}
