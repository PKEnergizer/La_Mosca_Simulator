using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoController : MonoBehaviour
{
    public Transform player; // Referencia al jugador (la mosca)
    public float detectionRadius = 5f; // Radio de detección para perseguir al jugador
    public float speed = 2f; // Velocidad de movimiento del gato
    public Animator animator; // Referencia al componente Animator

    private bool isChasing = false;

    void Start()
    {
        // Asegúrate de que la animación de patrullaje esté en ejecución al inicio
        animator.SetBool("isChasing", false);
    }

    void Update()
{
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    Debug.Log("Distance to Player: " + distanceToPlayer);

    if (distanceToPlayer <= detectionRadius)
    {
        Debug.Log("Player within detection radius");
        if (!isChasing)
        {
            isChasing = true;
            animator.SetBool("isChasing", true);
        }

        // Perseguir al jugador
        ChasePlayer();
    }
    else
    {
        Debug.Log("Player outside detection radius");
        if (isChasing)
        {
            isChasing = false;
            animator.SetBool("isChasing", false);
        }
    }
}

    void ChasePlayer()
    {
        // Moverse hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}