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
        InvokeRepeating(nameof(EmitSmoke), 0f, 1f); 
    }

    void EmitSmoke()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            
            GameObject smoke = Instantiate(smokePrefab, smokeSpawnPoint.position, Quaternion.identity);

            
            Rigidbody2D rb = smoke.GetComponent<Rigidbody2D>();

           
            if (rb != null)
            {
                
                Vector2 direction = Random.insideUnitCircle.normalized;
               
                rb.velocity = direction * smokeSpeed;
            }

            
            Destroy(smoke, smokeDuration);
        }
    }
}