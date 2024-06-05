using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform; 
    public Vector3 offset; 

    void Update()
    {
        if (cameraTransform != null)
        {
            
            transform.position = cameraTransform.position + offset;
        }
        else
        {
            Debug.LogWarning("No se ha asignado la cámara en el Inspector.");
        }
    }
}