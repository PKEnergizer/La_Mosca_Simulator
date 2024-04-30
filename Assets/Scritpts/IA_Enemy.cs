using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA_Enemy : MonoBehaviour
{
    public Animator animator; // Referencia al Animator Controller del enemigo
    public List<MonoBehaviour> waypointProviders; // Lista de scripts de rutas disponibles
    private IWaypointProvider currentWaypointProvider; // Ruta actual

    void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        // Seleccionar una ruta aleatoriamente al inicio
        SelectRandomWaypointProvider();

        // Retrasar la teletransportación de Jerry al primer waypoint
        StartCoroutine(TeleportToWaypoint());
    }

    IEnumerator TeleportToWaypoint()
    {
        yield return new WaitForEndOfFrame();

        if (currentWaypointProvider != null)
        {
            transform.position = currentWaypointProvider.CurrentWaypoint.position;
        }
    }

    void Update()
    {
        // Verificar si hay un proveedor de waypoints seleccionado
        if (currentWaypointProvider != null)
        {
            // Verificar si el enemigo ha llegado al waypoint actual
            if (Vector2.Distance(transform.position, currentWaypointProvider.CurrentWaypoint.position) < 0.1f)
            {
                // Mover al enemigo al siguiente waypoint
                currentWaypointProvider.SetNextWaypoint();
            }

            // Mover al enemigo hacia el waypoint actual
            transform.position = Vector2.MoveTowards(transform.position, currentWaypointProvider.CurrentWaypoint.position, currentWaypointProvider.Speed * Time.deltaTime);
        }

        // Actualizar el Animator Controller
        UpdateAnimation();
    }

    void SelectRandomWaypointProvider()
    {
        if (waypointProviders.Count == 0)
        {
            Debug.LogWarning("No hay scripts de rutas asignados.");
            return;
        }

        // Seleccionar un script de ruta aleatoriamente
        var randomProvider = waypointProviders[Random.Range(0, waypointProviders.Count)];

        // Asignar el script de ruta seleccionado al proveedor actual
        currentWaypointProvider = randomProvider as IWaypointProvider;

        if (currentWaypointProvider == null)
        {
            Debug.LogWarning("El script de ruta seleccionado no implementa IWaypointProvider.");
        }
    }

    void UpdateAnimation()
    {
        // Obtener la dirección del movimiento
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Determinar si Jerry se está moviendo hacia la derecha o izquierda
        bool movingRight = movementDirection.x > 0;
        bool movingLeft = movementDirection.x < 0;

        // Determinar si Jerry se está moviendo hacia arriba o abajo
        bool movingUp = movementDirection.y > 0;
        bool movingDown = movementDirection.y < 0;

        // Actualizar los parámetros del Animator según la dirección del movimiento
        animator.SetBool("AnimacionDerecha", movingRight);
        animator.SetBool("AnimacionIzquierda", movingLeft);
        animator.SetBool("AnimacionArriba", movingUp);
        animator.SetBool("AnimacionAbajo", movingDown);
    }
}