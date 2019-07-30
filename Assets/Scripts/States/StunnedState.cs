using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : BaseState
{
    // STUNNED state can transition to the following states
    // IDLE 
        // add more as we create them

    StateManager stateManager;

    public StunnedState(StateManager state) : base(state.gameObject)
    {
        stateManager = state;
    }

    public override Type Tick()
    {
        Debug.Log("Stunned State");

        if (stateManager._Zinp)
        {
            Debug.Log("test");
            return typeof(IdleState);
        }
        return null;
    }
}
