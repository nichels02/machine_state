using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public Transform target; // El objeto al que queremos llegar
    public float SpeedRotation = 5f;
    public float maxSpeed = 5f; // Velocidad máxima del objeto
    public float slowingDistance = 5f; // Distancia a partir de la cual el objeto comenzará a desacelerar
    public float stoppingDistance = 1f; // Distancia a partir de la cual el objeto se detendrá
    public bool Finalizo;



    void Update()
    {
        if (!Finalizo)
        {
            if (target != null)
            {
                print(target.gameObject.name);
            }
            else
            {
                print("es nulo");
            }
            
            // Calcula la dirección hacia el objetivo
            Vector3 targetDirection = target.position - transform.position;
            print("avanza2");
            // Calcula la distancia al objetivo
            float distance = targetDirection.magnitude;
            

            // Calcula la velocidad deseada
            float desiredSpeed = maxSpeed;

            // Si estamos dentro de la distancia de frenado, ajusta la velocidad
            if (distance < slowingDistance)
            {
                desiredSpeed = maxSpeed * (distance / slowingDistance);
            }

            // Si estamos dentro de la distancia de parada, detén completamente
            if (distance < stoppingDistance)
            {
                desiredSpeed = 0f;
            }


            // Calcula la fuerza de dirección hacia la velocidad deseada
            //transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDirection.normalized), SpeedRotation * Time.deltaTime);


            transform.position += transform.forward * Time.deltaTime * desiredSpeed;
        }
        

    }
}

