using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Dictionary<Type, BaseState> _states;

    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;


    void Update()
    {
        if(CurrentState == null)
        {
            CurrentState = _states.Values.First();
        }

        var nextState = CurrentState?.Tick();

        if(nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
            //OnStateChanged?.Invoke(CurrentState);
        }
    }

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _states = states;
    }

    private void SwitchToNewState(Type _nextState)
    {
        CurrentState = _states[_nextState];
    }
}
