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
        // Ocultar el cursor del ratón al inicio
        Cursor.visible = false;
    }

    void Update()
    {

        // Obtener la entrada del jugador en el eje vertical (solo hacia arriba)
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento en Y
        float movimientoY = 0f;

        // Movimiento en Y
        if (movimientoVertical > 0) // Arriba
        {
            movimientoY = 1f;
        }

        // Normalizar el vector de movimiento
        Vector2 movimientoDeseado = new Vector2(0f, movimientoY).normalized;

        // Aplicar el movimiento gradual al jugador
        movimientoActual = Vector2.Lerp(movimientoActual, movimientoDeseado, Time.deltaTime * factorDeslizamiento);

        // Obtener la posición del ratón en el mundo
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección hacia el ratón
        Vector3 direccionHaciaRaton = posicionRaton - transform.position;
        direccionHaciaRaton.z = 0; // Asegurar que no haya componente Z

        // Rotar la mosca para que mire hacia el ratón
        transform.up = direccionHaciaRaton.normalized;

        // Aplicar el movimiento al jugador
        transform.Translate(movimientoActual * velocidad * Time.deltaTime);

    }

}