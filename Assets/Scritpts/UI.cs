using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image puntero; // Referencia al GameObject del puntero
    public Transform mosca; // Referencia al GameObject de la mosca
    public float distanciaMinima = 3.0f; // Distancia mínima entre el puntero y la mosca

    void Start()
    {
        // Ocultar el puntero del sistema operativo
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la posición del ratón en la pantalla
        Vector3 posicionRaton = Input.mousePosition;

        // Convertir la posición del ratón a coordenadas del mundo
        Vector3 posicionEnMundo = Camera.main.ScreenToWorldPoint(posicionRaton);
        posicionEnMundo.z = 0f; // Asegurarse de que el puntero esté en el mismo plano que el juego

        // Verificar si la mosca está definida
        if (mosca != null)
        {
            // Calcular la distancia entre el puntero y la mosca
            float distancia = Vector3.Distance(posicionEnMundo, mosca.position);

            // Verificar si la distancia es mayor que la distancia mínima permitida
            if (distancia > distanciaMinima)
            {
                // Actualizar la posición del GameObject del puntero
                puntero.transform.position = posicionEnMundo;
            }
        }
        else
        {
            Debug.LogWarning("La referencia a la mosca no está asignada en el script UI.");
        }
    }
}