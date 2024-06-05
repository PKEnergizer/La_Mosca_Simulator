using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image puntero; 

    void Start()
    {
        
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la posición del ratón en la pantalla
        Vector3 posicionRaton = Input.mousePosition;

        
        Vector3 posicionEnMundo = Camera.main.ScreenToWorldPoint(posicionRaton);
        posicionEnMundo.z = 0f; // Asegurarse de que el puntero esté en el mismo plano que el juego

        
        puntero.transform.position = posicionEnMundo;
    }
}