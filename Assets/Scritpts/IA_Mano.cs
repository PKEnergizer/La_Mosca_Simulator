using UnityEngine;

public class IA_Mano : MonoBehaviour
{
    public Transform mosca; // Referencia al GameObject de la mosca
    public float speed = 5.0f; // Velocidad de movimiento de la mano
    public float attackRadius = 1.5f; // Radio para activar la secuencia de ataque
    public float followRadius = 5.0f; // Radio de persecución de la mosca
    public float attackDuration = 4.0f; // Duración del ataque (en segundos)
    public float attackSpeed = 10.0f; // Velocidad de ataque de la mano

    private float attackTimer = 0.0f; // Temporizador para controlar el ataque

    void Update()
    {
        float distanceToMosca = Vector2.Distance(transform.position, mosca.position);

        // Verificar si la mano está dentro del radio de persecución de la mosca
        if (distanceToMosca <= followRadius)
        {
            // Orientar la mano hacia la mosca
            Vector2 direction = (mosca.position - transform.position).normalized;
            transform.up = direction;

            // Mover la mano hacia la mosca si no está en el radio de ataque
            if (distanceToMosca > attackRadius)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }

            // Verificar si se debe activar el ataque
            if (distanceToMosca <= attackRadius && attackTimer <= 0.0f)
            {
                // Iniciar el temporizador de ataque
                attackTimer = attackDuration;
            }
        }

        // Contar hacia atrás el temporizador de ataque
        if (attackTimer > 0.0f)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0.0f)
            {
                // Realizar el ataque "Manotazo"
                ManotazoAttack();
            }
        }
    }

    void ManotazoAttack()
    {
        // Alejar la mano un poco para cargar el ataque
        Vector2 direction = (transform.position - mosca.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Después de cargar, dirigirse rápidamente hacia la mosca
        transform.position += (Vector3)direction * attackSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la mano ha golpeado a la mosca
        if (other.CompareTag("Mosca"))
        {
            // Realizar acciones al golpear a la mosca, como aplicar daño, iniciar animaciones, etc.
            Debug.Log("¡La mano golpeó a la mosca!");
        }
    }
}