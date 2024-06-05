using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Mosca : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del jugador
    public float factorDeslizamiento = 2f; // Factor para controlar el deslizamiento

    private Vector2 movimientoActual; // Vector de movimiento actual

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

       
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento en Y
        float movimientoY = 0f;

        // Movimiento en Y
        if (movimientoVertical > 0) // Arriba
        {
            movimientoY = 1f;
        }

        Vector2 movimientoDeseado = new Vector2(0f, movimientoY).normalized;

        movimientoActual = Vector2.Lerp(movimientoActual, movimientoDeseado, Time.deltaTime * factorDeslizamiento);

        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direccionHaciaRaton = posicionRaton - transform.position;
        direccionHaciaRaton.z = 0; 

        transform.up = direccionHaciaRaton.normalized;

        transform.Translate(movimientoActual * velocidad * Time.deltaTime);

    }

}