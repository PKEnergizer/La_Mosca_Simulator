using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaComun_IA : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float changeDirectionTime = 1f;
    private Vector2 direction; 
    private float changeDirectionTimer; 

    void Start()
    {

        changeDirectionTimer = changeDirectionTime;
        ChangeDirection();
    }

    void Update()
    {
        // Mover la mosca en la dirección actual
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0f)
        {
            ChangeDirection();
            changeDirectionTimer = changeDirectionTime;
        }
    }

    void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}