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
        //print("1");
        if (EstaInvertido)
        {
            //print("2");
            ReverseArray();
            EstaInvertido = false;
            
        }
        if (RecienEmpezo)
        {
            RecienEmpezo = false;
            ElPathFollowing.currentPointIndex = 0;
            ElPathFollowing.ListaDeTransforms = ListaDeMovimiento;
            ElArrive.Finalizo = false;
        }

        //print("3");
        
        ElPathFollowing.NextPoint();
        
        if (ElArrive.Finalizo)
        {
            print("4");
            Etapa = EtapaState.Execute;
            RecienEmpezo = true;
        }
        //print("5");

    }
    public override void Execute()
    {
        LasStats.hambre = Mathf.Clamp(LasStats.hambre + Time.deltaTime * 20, 0, 100);
        LasStats.sueno = Mathf.Clamp(LasStats.sueno - Time.deltaTime * 0.5f, 0, 100);
        LasStats.wc = Mathf.Clamp(LasStats.wc - Time.deltaTime * 3, 0, 100);

        if (LasStats.hambre == 100)
        {
            Etapa = EtapaState.Exit;
            //m_MachineState.NextState(TypeState.Jugar);
        }
    }
    public override void Exit()
    {
        if (!EstaInvertido)
        {
            ReverseArray();
            EstaInvertido = true;
            
        }
        if (RecienEmpezo)
        {
            RecienEmpezo = false;
            ElPathFollowing.currentPointIndex = 0;
            ElPathFollowing.ListaDeTransforms = ListaDeMovimiento;
            ElArrive.Finalizo = false;
        }
        
        ElPathFollowing.NextPoint();
        if (ElArrive.Finalizo)
        {
            m_MachineState.NextState(TypeState.Jugar);
            RecienEmpezo = true;
        }
    }
}
