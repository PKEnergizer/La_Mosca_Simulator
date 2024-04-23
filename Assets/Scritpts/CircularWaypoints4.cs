using UnityEngine;
using System.Collections.Generic;

public class CircularWaypoints4 : MonoBehaviour, IWaypointProvider
{
    public List<Transform> waypoints; // Lista de waypoints para la ruta circular
    public float speed = 2.0f; // Velocidad de movimiento entre waypoints

    // Nombres de los waypoints en orden
    private string[] waypointNames = { "Punto_G", "Punto_F", "Punto_E", "Punto_C", "Punto_B",
                                       "Punto_A", "Punto_B", "Punto_C", "Punto_H", "Punto_I",
                                       "Punto_H", "Punto_E", "Punto_F", "Punto_G" };

    private int currentWaypointIndex = 0; // Índice del waypoint actual

    void Start()
    {
        // Inicializar la lista de waypoints basada en los nombres
        waypoints = new List<Transform>();
        foreach (var name in waypointNames)
        {
            var waypoint = transform.Find(name);
            if (waypoint != null)
            {
                waypoints.Add(waypoint);
            }
            else
            {
                Debug.LogWarning($"No se encontró el waypoint con el nombre {name}.");
            }
        }
    }

    public Transform CurrentWaypoint => waypoints[currentWaypointIndex];
    public float Speed => speed;

    public void SetNextWaypoint()
    {
        // Obtener el siguiente waypoint circularmente
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
    }
}