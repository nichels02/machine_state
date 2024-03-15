using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : State
{
    stats LasStats;
    void Start()
    {
        LasStats = GetComponent<stats>();
        LoadComponent();
    }
    
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    public override void Enter()
    {

    }
    public override void Execute()
    {
        LasStats.hambre = Mathf.Clamp(LasStats.hambre - Time.deltaTime * 5, 0, 100);
        LasStats.sueno = Mathf.Clamp(LasStats.sueno - Time.deltaTime * 0.5f, 0, 100);
        LasStats.wc = Mathf.Clamp(LasStats.wc - Time.deltaTime * 3, 0, 100);

        if (LasStats.hambre == 0)
        {
            m_MachineState.NextState(TypeState.Comer);
        }
        else if (LasStats.wc == 0)
        {
            m_MachineState.NextState(TypeState.Banno);
        }
        else if (LasStats.sueno == 0)
        {
            m_MachineState.NextState(TypeState.Dormir);
        }
    }
    public override void Exit()
    {

    }
}
