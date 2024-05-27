using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmokeEmitter : MonoBehaviour
{
    public GameObject smokePrefab; // Prefab de las partículas de humo
    public Transform smokeSpawnPoint; // Punto de origen de las partículas de humo
    public float smokeSpeed = 5f; // Velocidad de las partículas de humo
    public float smokeDuration = 2f; // Duración de vida de las partículas de humo
    public int numberOfParticles = 20; // Número de partículas generadas por emisión

    void Start()
    {
        // Inicia la emisión de humo de forma continua
        InvokeRepeating(nameof(EmitSmoke), 0f, 1f); // Llama a EmitSmoke cada segundo
    }

    void EmitSmoke()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            // Instanciar las partículas de humo en el punto de origen
            GameObject smoke = Instantiate(smokePrefab, smokeSpawnPoint.position, Quaternion.identity);

            // Obtener el componente Rigidbody de las partículas de humo
            Rigidbody2D rb = smoke.GetComponent<Rigidbody2D>();

            // Si se encuentra el componente Rigidbody
            if (rb != null)
            {
                // Generar una dirección aleatoria
                Vector2 direction = Random.insideUnitCircle.normalized;
                // Aplicar una velocidad a las partículas de humo en la dirección especificada
                rb.velocity = direction * smokeSpeed;
            }

            // Destruir las partículas de humo después de un cierto tiempo
            Destroy(smoke, smokeDuration);
        }
    }
}