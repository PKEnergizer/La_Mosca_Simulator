using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator; // Referencia al Animator Controller del personaje
    public float speed = 5f; // Velocidad de movimiento del personaje

    void Update()
    {
        // Obtener la dirección de movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        // Mover al personaje
        transform.Translate(movement * speed * Time.deltaTime);

        // Actualizar la animación del personaje
        UpdateAnimation(movement);
    }

    void UpdateAnimation(Vector3 movement)
    {
        // Obtener la dirección de movimiento en los ejes X e Y
        bool movingRight = movement.x > 0;
        bool movingLeft = movement.x < 0;
        bool movingUp = movement.y > 0;
        bool movingDown = movement.y < 0;

        // Actualizar los parámetros del Animator según la dirección del movimiento
        animator.SetBool("MovingRight", movingRight);
        animator.SetBool("MovingLeft", movingLeft);
        animator.SetBool("MovingUp", movingUp);
        animator.SetBool("MovingDown", movingDown);

        // Configurar el parámetro de velocidad de movimiento para la animación
        float movementSpeed = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);
        animator.SetFloat("MovementSpeed", movementSpeed);
    }
}