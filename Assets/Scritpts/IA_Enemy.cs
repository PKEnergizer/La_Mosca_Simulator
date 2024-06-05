using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA_Enemy : MonoBehaviour
{
    public List<MonoBehaviour> waypointProviders; 
    private IWaypointProvider currentWaypointProvider; 
    public Transform player; 
    public float detectionRadius = 5f; 
    public float chaseSpeed = 3f; 
    public Transform manosController; 
    public float proximityRadius = 3f; 

    void Start()
    {
        // Seleccionar una ruta aleatoriamente al inicio
        SelectRandomWaypointProvider();

        // Retrasar la teletransportación al primer waypoint
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
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < proximityRadius)
        {
            // Teletransportar ManosController a la posición del jugador
            TeleportManosController();
        }

        if (distanceToPlayer < detectionRadius)
        {
            // Perseguir al jugador
            ChasePlayer();
        }
        else
        {
            // Seguir la ruta de waypoints
            FollowWaypoints();
        }
    }

    void TeleportManosController()
    {
        if (manosController != null)
        {
            manosController.position = player.position;
        }
    }

    void ChasePlayer()
    {
        // Mover al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void FollowWaypoints()
    {
        // Verificar si hay un proveedor de waypoints seleccionado
        if (currentWaypointProvider != null)
        {
            
            if (Vector2.Distance(transform.position, currentWaypointProvider.CurrentWaypoint.position) < 0.1f)
            {
                // Mover al enemigo al siguiente waypoint
                currentWaypointProvider.SetNextWaypoint();
            }

            
            transform.position = Vector2.MoveTowards(transform.position, currentWaypointProvider.CurrentWaypoint.position, currentWaypointProvider.Speed * Time.deltaTime);
        }
    }

    void SelectRandomWaypointProvider()
    {
        if (waypointProviders.Count == 0)
        {
            Debug.LogWarning("No hay scripts de rutas asignados.");
            return;
        }

        
        var randomProvider = waypointProviders[Random.Range(0, waypointProviders.Count)];

        
        currentWaypointProvider = randomProvider as IWaypointProvider;

        if (currentWaypointProvider == null)
        {
            Debug.LogWarning("El script de ruta seleccionado no implementa IWaypointProvider.");
        }
    }
}