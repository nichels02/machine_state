using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EtapaDelProceso
{
    enter,
    Execute,
    Exit,
}
public class Dormir : State
{
    EtapaDelProceso LaEtapa;
     
    void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        type = TypeState.Dormir;
    }
    // Update is called once per frame
    //void Update()
    //{
    //    switch (LaEtapa)
    //    {
    //        case EtapaDelProceso.enter:
    //            {

    //            }
    //            break;
    //        case EtapaDelProceso.Execute:
    //            {
    //                Execute();
    //            }
    //            break;
    //        case EtapaDelProceso.Exit:
    //            {

    //            }
    //            break;
    //    }
    //}

    public override void Enter()
    {

    }
    public override void Execute()
    {
        LasStats.hambre = Mathf.Clamp(LasStats.hambre - Time.deltaTime * 5, 0, 100);
        LasStats.sueno = Mathf.Clamp(LasStats.sueno + Time.deltaTime * 2, 0, 100);
        LasStats.wc = Mathf.Clamp(LasStats.wc - Time.deltaTime * 3, 0, 100);

        if (LasStats.sueno == 100)
        {
            m_MachineState.NextState(TypeState.Jugar);
        }
    }
    public override void Exit()
    {

    }
}
