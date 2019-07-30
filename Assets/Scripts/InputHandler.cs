using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float vertical;
    public float horizontal;

    public bool Zinp;
    public bool Xinp;
    public bool Cinp;
    public bool Vinp;

    public float Ztimer;
    public float Xtimer;
    public float Ctimer;
    public float Vtimer;

    public bool ChangeControls = false;
    public string Z_Key = "";

    StateManager stateManager;
    float delta;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateManager>();
        stateManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;

        stateManager.Tick(delta);
        GetInput();





        //if (ChangeControls)
        //{
        //    ConfigureControllerInputs();
        //    ChangeControls = false;
        //}
    }


    void FixedUpdate()
    {
        delta = Time.fixedDeltaTime;

        UpdateStates();
        stateManager.FixedTick(delta);

        ResetTimers();
    }






    void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Zinp = Input.GetKey(KeyCode.Z);
        Xinp = Input.GetKey(KeyCode.X);
        Cinp = Input.GetKey(KeyCode.C);
        Vinp = Input.GetKey(KeyCode.V);

        if (Zinp) { Ztimer += delta; }
        if (Xinp) { Xtimer += delta; }
        if (Cinp) { Ctimer += delta; }
        if (Vinp) { Vtimer += delta; }
    }


    void UpdateStates()
    {
        stateManager._vertical = vertical;
        stateManager._horizontal = horizontal;

        Vector3 v = vertical * gameObject.transform.forward;
        Vector3 h = horizontal * gameObject.transform.right;
        stateManager._MoveDirection = (v + h).normalized;

        float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        stateManager._MoveAmount = Mathf.Clamp01(m);

        stateManager._Zinp = Zinp;
        stateManager._Xinp = Xinp;
        stateManager._Cinp = Cinp;
        stateManager._Vinp = Vinp;

        if(Zinp && Ztimer > 0.5)
        {
            stateManager._Zcharge = true;
        }

        if(!Zinp && Ztimer > 0 && Ztimer < 0.5)
        {
            stateManager._Zinp = true;
        }
    }

    void ResetTimers()
    {
        if (!Zinp)
        {
            Ztimer = 0;
        }

        if (!Xinp)
        {
            Xtimer = 0;
        }

        if (!Cinp)
        {
            Ctimer = 0;
        }

        if (!Vinp)
        {
            Vtimer = 0;
        }

        if (stateManager._Zcharge)
        {
            Debug.Log("ZCHARGE");
            stateManager._Zcharge = false;
        }
    }



    void ConfigureControllerInputs()
    {
        Z_Key = "KeyCode." + Z_Key;

        Debug.Log(Z_Key);
    }
}
