using UnityEngine;

public class CarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -5f); 
    public float smoothSpeed = 0.125f; 

    void LateUpdate()
    {
        // Si el objetivo no está asignado, salir del método
        if (target == null)
        {
            return;
        }

        // Calcular la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;

        // Interpolación suave hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Establecer la posición de la cámara
        transform.position = smoothedPosition;

        // Apuntar la cámara hacia el objetivo
        transform.LookAt(target);
    }
}

