using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : BaseState
{
    StateManager stateManager;

    public DodgeState(StateManager state) : base(state.gameObject)
    {
        stateManager = state;
    }

    public override Type Tick()
    {
        Debug.Log("Dodge State");

        if (stateManager._Zinp)
        {
            Debug.Log("test");
            return typeof(AttackState);
        }
        return null;
    }
}
