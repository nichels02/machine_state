using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineState : MonoBehaviour
{
    public State CurrentState;
    public State []m_States;
    public TypeState stateDefaul;
    private void Start()
    {
        m_States = GetComponents<State>();
        foreach (var item in m_States)
        {
            if (item.type == stateDefaul)
            {
                    item.Enter();

                    item.enabled = true;

                    CurrentState = item;
            }
            else
            {
                item.enabled = false;
            }

        }
    }
    public void NextState(TypeState state)
    {
        foreach (var item in m_States)
        {
            if(item.type == state)
            {
                if (CurrentState != null)
                {
                    CurrentState.Exit();
                    CurrentState.enabled = false;

                    CurrentState = item;
                    CurrentState.enabled=true;
                    CurrentState.Etapa = EtapaState.Enter;
                }
                   
            }
            
        }
    }
    public void DesactiveStateAll()
    {
        foreach (var item in m_States)
        {
            item.enabled = false;
        }
    }
    private void Update()
    {
        if (CurrentState != null)
        {
            switch (CurrentState.Etapa)
            {
                case EtapaState.Enter:
                    {
                        CurrentState.Enter();
                    }
                    break;
                case EtapaState.Execute:
                    {
                        CurrentState.Execute();
                    }
                    break;
                case EtapaState.Exit:
                    {
                        CurrentState.Exit();
                    }
                    break;
            }
        }
            
    }
}
