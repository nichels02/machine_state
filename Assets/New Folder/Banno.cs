using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banno : State
{
    

    void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        type = TypeState.Banno;
    }
    // Update is called once per frame
     
    public override void Enter()
    {

    }
    public override void Execute()
    {
        LasStats.hambre = Mathf.Clamp(LasStats.hambre - Time.deltaTime * 5, 0, 100);
        LasStats.sueno = Mathf.Clamp(LasStats.sueno - Time.deltaTime * 0.5f, 0, 100);
        LasStats.wc = Mathf.Clamp(LasStats.wc + Time.deltaTime * 50, 0, 100);

        if (LasStats.wc == 100)
        {
            m_MachineState.NextState(TypeState.Jugar);
        }
    }
    public override void Exit()
    {

    }
}
