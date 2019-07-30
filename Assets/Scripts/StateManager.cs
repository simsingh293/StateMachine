using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // State Manager holds all the Inputs which are then accessed
    // by the different State classes to control the character's
    // animations and physics(movement, root motion, etc.)

    public float speed = 5;

    public float _vertical;
    public float _horizontal;
    public Vector3 _MoveDirection;
    public float _MoveAmount;
    public bool _Zinp;
    public bool _Xinp;
    public bool _Cinp;
    public bool _Vinp;
    public bool _Zcharge;
    public bool _Xcharge;
    public bool _Ccharge;
    public bool _Vcharge;

    float delta;

    public enum MovementStates
    {
        FreeRun,
        Combat
    }

    StateMachine machine;
    Rigidbody _rb;

    public enum TestStates
    {
        Idle,
        Run,
        Attack,
        Dodge,
        Stunned
    }

    public void Init()
    {
        // Initialize all components that are part of this entity
        // ie. Movement, Dodging, Health, etc.
        Debug.Log("State Manager Initialized");

        machine = GetComponent<StateMachine>();
        _rb = GetComponent<Rigidbody>();

        InitializeStateMachine();
    }

    public void Tick(float d)
    {
        delta = d;
    }

    public void FixedTick(float d)
    {
        delta = d;

        DetectAction();

        _rb.velocity = _MoveDirection * (speed * _MoveAmount);
        // Check if the player is attacking state
            // if YES
                // Increment timer for action delay
                // Check if action delay is greater than specified value
                    // if YES
                        // Disable attacking state
                        // reset action delay timer
                    // if NO
                        // return
    }

    void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(IdleState), new IdleState(state:this) },
            {typeof(RunState), new RunState(state:this) },
            {typeof(AttackState), new AttackState(state:this) },
            {typeof(DodgeState), new DodgeState(state:this) },
            {typeof(StunnedState), new StunnedState(state:this) }
        };

        machine.SetStates(states);
    }

    void DetectAction()
    {
        if(!_Zinp && !_Xinp && !_Cinp && !_Vinp) { return; }


    }
}
