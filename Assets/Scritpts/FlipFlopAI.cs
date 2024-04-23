using UnityEngine;
using System.Collections;

public class FlipFlopAI : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento de la sandalia
    public Transform mosca; // Referencia al transform de la mosca
    private Vector3 targetPosition; // Posición objetivo de la sandalia
    private Vector3 originalPosition; // Posición inicial de la sandalia

    void Start()
    {
        // Posicionar la sandalia fuera de la pantalla en la esquina inferior derecha
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        originalPosition = new Vector3(screenBounds.x, -screenBounds.y, 0);
        transform.position = originalPosition;

        // Iniciar el movimiento de la sandalia
        StartMovement();
    }

    public void StartMovement()
    {
        // Obtener la posición objetivo de la mosca
        targetPosition = mosca.position;

        // Mover la sandalia hacia la posición objetivo
        StartCoroutine(MoveTowardsTarget());
    }

    IEnumerator MoveTowardsTarget()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        // Esperar 2 segundos antes de cambiar la dirección y volver a atacar
        yield return new WaitForSeconds(2.0f);

        // Cambiar la dirección de la sandalia
        ChangeDirection();
    }

    void ChangeDirection()
    {
        // Mover la sandalia a la posición inicial
        targetPosition = originalPosition;

        // Mover la sandalia hacia la posición objetivo
        StartCoroutine(MoveTowardsTarget());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca"))
        {
            // Puedes añadir aquí la lógica para cuando la sandalia detecta a la mosca
            // Por ejemplo, hacer que la sandalia vuelva a la posición inicial o haga algo diferente
            ChangeDirection();
        }
    }
}