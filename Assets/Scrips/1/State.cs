using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeState { Comer,Jugar,Banno,Dormir}
public enum EtapaState { Enter, Execute, Exit}
public class State : MonoBehaviour
{
    public EtapaState Etapa;
    public TypeState type;
    public MachineState m_MachineState;
    public stats LasStats;

    public Arrive ElArrive;
    public PathFollowing ElPathFollowing;
    public Transform[] ListaDeMovimiento = new Transform[1];
    public bool EstaInvertido;
    public bool RecienEmpezo;
    public virtual void LoadComponent()
    {
        RecienEmpezo = true;
        m_MachineState = GetComponent<MachineState>();
        LasStats = GetComponent<stats>();
        ElArrive = GetComponent<Arrive>();
        ElPathFollowing = GetComponent<PathFollowing>();
    }
    public virtual void Enter( )
    {

    }
    public virtual void Execute()
    {

    }
    public virtual void Exit()
    {

    }

    public void ReverseArray()
    {
        for (int i = 0; i < ListaDeMovimiento.Length / 2; i++)
        {
            // Intercambiar los valores de inicio y fin
            Transform temp = ListaDeMovimiento[i];
            ListaDeMovimiento[i] = ListaDeMovimiento[ListaDeMovimiento.Length - i - 1];
            ListaDeMovimiento[ListaDeMovimiento.Length - i - 1] = temp;
        }
    }
}
