using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    // RUN state can transition to the following states
    // IDLE - ATTACK - DODGE - STUNNED
        // add more as we create them

    StateManager stateManager;

    public RunState(StateManager state) : base(state.gameObject)
    {
        stateManager = state;
    }

    public override Type Tick()
    {
        Debug.Log("Run State");

        if (stateManager._Zinp)
        {
            Debug.Log("test");
            return typeof(DodgeState);
        }
        return null;
    }
}
