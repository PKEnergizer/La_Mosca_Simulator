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
        // Aquí puedes agregar la lógica para actualizar la animación basada en la dirección del enemigo
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        Debug.Log("Horizontal: " + direction.x);
        Debug.Log("Vertical: " + direction.y);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}