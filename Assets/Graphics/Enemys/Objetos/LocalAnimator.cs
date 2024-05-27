using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAnimator : MonoBehaviour
{
    public Transform referenceTransform; // Transformación de referencia para la posición local

    void Update()
    {
        if (referenceTransform != null)
        {
            // Ajustar la posición local basada en la transformación de referencia
            transform.localPosition = referenceTransform.localPosition;
        }
    }
}