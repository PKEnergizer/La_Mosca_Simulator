using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manos_IA : MonoBehaviour
{
    public Transform Mosca; 
    public float detectionRadius = 10f; 
    public float stopRadius = 3f; 
    public float moveSpeed = 5f; 

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

        Vector2 direction = (Mosca.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Mosca.position, moveSpeed * Time.deltaTime);
    }
}