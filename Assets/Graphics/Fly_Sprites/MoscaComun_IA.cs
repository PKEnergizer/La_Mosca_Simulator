using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaComun_IA : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float changeDirectionTime = 1f; // Tiempo entre cambios de dirección
    private Vector2 direction; // Dirección de movimiento actual
    private float changeDirectionTimer; // Temporizador para cambiar de dirección

    void Start()
    {
        // Inicializar el temporizador y la dirección
        changeDirectionTimer = changeDirectionTime;
        ChangeDirection();
    }

    void Update()
    {
        // Mover la mosca en la dirección actual
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        // Actualizar el temporizador y cambiar de dirección si es necesario
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0f)
        {
            ChangeDirection();
            changeDirectionTimer = changeDirectionTime;
        }
    }

    void ChangeDirection()
    {
        // Elegir una nueva dirección aleatoria
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}