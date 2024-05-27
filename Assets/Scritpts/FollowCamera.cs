using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform; // La transformación de la cámara que queremos seguir
    public Vector3 offset; // Desplazamiento opcional desde la posición de la cámara

    void Update()
    {
        if (cameraTransform != null)
        {
            // Mover el contenedor para que siga la posición de la cámara con un desplazamiento opcional
            transform.position = cameraTransform.position + offset;
        }
        else
        {
            Debug.LogWarning("No se ha asignado la cámara en el Inspector.");
        }
    }
}