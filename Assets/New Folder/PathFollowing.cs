using UnityEngine;
using System.Collections.Generic;



[System.Serializable]
public class DataPath
{
    public TypeState type;
    public Transform[] paths;
    public DataPath()
    {

    }
}


public class PathFollowing : MonoBehaviour
{

    [SerializeField] MachineState ElJugador;
    [SerializeField] List<DataPath> datapaths = new List<DataPath>();
    public List<Transform> pathPoints;
    public Transform currentPoints;
    //public float speed = 5f;
    //public float SpeedRotation = 5f;
    public float arrivalDistance = 0.1f;

    private int currentPointIndex = 0;
    private int currentPointEstado = 0;

    public bool IsDrawGizmo;
    public Color ColorGizmoPath;
    public Color ColorGizmoCurrentPoint;
    private void Start()
    {
        currentPoints = pathPoints[0];
    }
    public bool NextPoint()
    {
        if (Vector3.Distance(transform.position, datapaths[currentPointEstado].paths[currentPointIndex].position) < arrivalDistance)
        {
            // Avanzar al siguiente punto de la ruta
            switch (ElJugador.CurrentState.type)
            {
                case TypeState.Banno:
                    {
                        if (TypeState.Banno != datapaths[currentPointEstado].type)
                        {
                            for(int i=0; i< datapaths.Count; i++)
                            {
                                if (datapaths[i].type == TypeState.Banno)
                                {
                                    currentPointEstado = i;
                                    i = datapaths.Count;
                                }
                            }
                        }
                        return NextPoint2();

                    }
                    break;
                case TypeState.Comer:
                    {
                        if (TypeState.Comer != datapaths[currentPointEstado].type)
                        {
                            for (int i = 0; i < datapaths.Count; i++)
                            {
                                if (datapaths[i].type == TypeState.Comer)
                                {
                                    currentPointEstado = i;
                                    i = datapaths.Count;
                                }
                            }
                        }
                        return NextPoint2();
                    }
                    break;
                case TypeState.Dormir:
                    {
                        if (TypeState.Banno != datapaths[currentPointEstado].type)
                        {
                            for (int i = 0; i < datapaths.Count; i++)
                            {
                                if (datapaths[i].type == TypeState.Banno)
                                {
                                    currentPointEstado = i;
                                    i = datapaths.Count;
                                }
                            }
                        }
                        return NextPoint2();
                    }
                    break;
                case TypeState.Jugar:
                    {
                        return NextPoint3();
                    }
                    break;
                default:
                    return false;
                    break;
            }
            
        }
        else
        {
            return false;
        }
    }


    bool NextPoint2()
    {
        if (currentPointIndex < datapaths[currentPointEstado].paths.Length)
        {
            currentPointIndex++;
            return false;
        }
        else
        {
            return true;
        }

        
    }

    bool NextPoint3()
    {
        if (currentPointIndex > 0)
        {
            currentPointIndex--;
            return false;
        }
        else
        {
            return true;
        }


    }


    private void OnDrawGizmos()
    {
        if (!IsDrawGizmo) return;

        if (currentPoints != null)
        {
            Gizmos.color = ColorGizmoCurrentPoint;
            Gizmos.DrawSphere(currentPoints.position, 0.8f);
        }
        Gizmos.color = ColorGizmoPath;
        for (int i = 0; i < pathPoints.Count - 1; i++)
        {
            Gizmos.DrawWireSphere(pathPoints[i].position, 0.5f);

            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }

        Gizmos.DrawWireSphere(pathPoints[pathPoints.Count - 1].position, 0.5f);

    }
}