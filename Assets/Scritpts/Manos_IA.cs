using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manos_IA : MonoBehaviour
{
    public Transform Mosca; // Referencia al jugador "Mosca"
    public float detectionRadius = 10f; // Radio de detección
    public float stopRadius = 3f; // Radio mínimo de distancia
    public float moveSpeed = 5f; // Velocidad de movimiento

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Mosca.position);

        if (distanceToPlayer < detectionRadius && distanceToPlayer > stopRadius)
        {
            // Seguir al jugador
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Mover el objeto "ManosController" hacia el jugador
        Vector2 direction = (Mosca.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Mosca.position, moveSpeed * Time.deltaTime);
    }
}