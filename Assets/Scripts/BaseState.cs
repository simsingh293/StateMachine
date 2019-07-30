using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject obj;
    protected Transform transform;

    public BaseState(GameObject gameObject)
    {
        this.obj = gameObject;
        this.transform = gameObject.transform;
    }

    public abstract Type Tick();
}
