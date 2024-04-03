using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : State
{
     
    void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        type = TypeState.Comer;
    }

    // Update is called once per frame
     
    public override void Enter()
    {

    }
    public override void Execute()
    {
        LasStats.hambre = Mathf.Clamp(LasStats.hambre + Time.deltaTime * 20, 0, 100);
        LasStats.sueno = Mathf.Clamp(LasStats.sueno - Time.deltaTime * 0.5f, 0, 100);
        LasStats.wc = Mathf.Clamp(LasStats.wc - Time.deltaTime * 3, 0, 100);

        if (LasStats.hambre == 100)
        {
            m_MachineState.NextState(TypeState.Jugar);
        }
    }
    public override void Exit()
    {

    }
}
