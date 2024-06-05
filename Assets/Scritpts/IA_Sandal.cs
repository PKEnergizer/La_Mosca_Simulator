using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Sandal : MonoBehaviour
{
    public Camera mainCamera; // Referencia a la cámara principal
    public float rotationSpeed = 30.0f; // Velocidad de rotación de la sandalia
    public float rotationRadius = 2.0f; // Radio de rotación en relación a la cámara
    public float rotationX = 0.0f; 
    public float rotationY = 1.0f; 
    public float rotationZ = 0.0f; 

    void Update()
    {
       
        if (mainCamera != null)
        {
     
            Vector3 rotationPosition = mainCamera.transform.position;
            rotationPosition += (transform.position - mainCamera.transform.position).normalized * rotationRadius;

    
            Vector3 directionToRotation = (rotationPosition - transform.position).normalized;

    
            float rotationAngleX = rotationX * rotationSpeed * Time.deltaTime;
            float rotationAngleY = rotationY * rotationSpeed * Time.deltaTime;
            float rotationAngleZ = rotationZ * rotationSpeed * Time.deltaTime;

            transform.RotateAround(rotationPosition, Vector3.right, rotationAngleX);
            transform.RotateAround(rotationPosition, Vector3.up, rotationAngleY);
            transform.RotateAround(rotationPosition, Vector3.forward, rotationAngleZ);
        }
        else
        {
            Debug.LogWarning("La referencia a la cámara principal no está asignada en el script IA_Sandal.");
        }
    }
}