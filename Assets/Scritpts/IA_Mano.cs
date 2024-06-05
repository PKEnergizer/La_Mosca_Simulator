using UnityEngine;

public class IA_Mano : MonoBehaviour
{
    public Transform mosca; 
    public float speed = 5.0f; 
    public float attackRadius = 1.5f; 
    public float followRadius = 5.0f; 
    public float attackDuration = 4.0f; 
    public float attackSpeed = 10.0f; 

    private float attackTimer = 0.0f; 

    void Update()
    {
        float distanceToMosca = Vector2.Distance(transform.position, mosca.position);

        // Verificar si la mano está dentro del radio de persecución de la mosca
        if (distanceToMosca <= followRadius)
        {
            
            Vector2 direction = (mosca.position - transform.position).normalized;
            transform.up = direction;

            
            if (distanceToMosca > attackRadius)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }

            
            if (distanceToMosca <= attackRadius && attackTimer <= 0.0f)
            {
                
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
        if (other.CompareTag("Mosca"))
        {
            //Debug.Log("¡La mano golpeó a la mosca!");
        }
    }
}