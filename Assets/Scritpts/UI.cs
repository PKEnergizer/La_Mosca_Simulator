using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image puntero; // Referencia al GameObject del puntero

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

        // Actualizar la posición del GameObject del puntero
        puntero.transform.position = posicionEnMundo;
    }
}