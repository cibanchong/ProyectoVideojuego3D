using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovimiento : MonoBehaviour
{
    public float speed = 3f; 
    public float rotationSpeed = 100.0f;
    private bool isStopped = false;

    void Start()
    {
        
    }

    void Update()
    {
        // Acelerar hacia adelante con W
        if (Input.GetKey(KeyCode.W) && !isStopped)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Girar a la izquierda con A
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Girar a la derecha con D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Detener con S
        if (Input.GetKeyDown(KeyCode.S))
        {
            isStopped = !isStopped; 
        }

        // Rotar adicionalmente con R
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}