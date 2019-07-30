using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    StateManager stateManager;

    public AttackState(StateManager state) : base(state.gameObject)
    {
        stateManager = state;
    }

    public override Type Tick()
    {

        Debug.Log("Attack State");

        if (stateManager._Zinp)
        {
            Debug.Log("test");
            return typeof(StunnedState);
        }
        return null;
    }
}
