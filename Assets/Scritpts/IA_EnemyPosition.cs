using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_EnemyPosition : MonoBehaviour
{
    public Transform mosca; // Referencia al GameObject de la mosca
    public GameObject EnemyPosition; // Objeto vacío que se teletransportará cerca de la mosca
    public List<GameObject> enemies; // Lista de enemigos asignables
    public float teleportDistance = 5.0f; // Distancia a la que se teletransportará el objeto desde la mosca
    public float teleportInterval = 5.0f; // Intervalo de tiempo entre cada teletransporte
    private float enemySpawnCooldown = 20.0f; // Tiempo de enfriamiento inicial entre cada generación de enemigos
    private float contadorInterno = 120.0f; // Duración total del contador interno en segundos (2 minutos)

    private bool isTeleported = false; // Variable para controlar si el objeto se ha teletransportado
    private float timer = 0.0f; // Temporizador para controlar el intervalo de teletransporte
    private float enemySpawnTimer = 0.0f; // Temporizador para controlar el enfriamiento de generación de enemigos

    void Start()
    {
        // Posicionar el objeto cerca de la mosca al inicio
        TeleportToRandomSide();
    }

    void Update()
    {
        // Actualizar el temporizador de teletransporte
        timer += Time.deltaTime;

        // Verificar si ha pasado el intervalo de teletransporte
        if (timer >= teleportInterval)
        {
            // Teletransportar el objeto a una nueva posición aleatoria
            TeleportToRandomSide();

            // Reiniciar el temporizador de teletransporte
            timer = 0.0f;
        }

        // Actualizar el temporizador de enfriamiento de generación de enemigos
        enemySpawnTimer += Time.deltaTime;

        // Verificar si ha pasado el enfriamiento de generación de enemigos
        if (enemySpawnTimer >= enemySpawnCooldown)
        {
            // Generar enemigos si la lista no está vacía
            if (enemies.Count > 0)
            {
                int randomIndex = Random.Range(0, enemies.Count);
                GameObject selectedEnemy = enemies[randomIndex];
                selectedEnemy.transform.position = EnemyPosition.transform.position;
            }

            // Reiniciar el temporizador de enfriamiento de generación de enemigos
            enemySpawnTimer = 0.0f;
        }

        // Actualizar el contador interno y el enfriamiento de generación de enemigos
        UpdateInternalCounterAndCooldown();
    }

    void TeleportToRandomSide()
    {
        // Generar una posición aleatoria a la izquierda o a la derecha de la mosca
        Vector2 randomDirection = Random.insideUnitCircle.normalized * teleportDistance;
        Vector2 randomPosition = (Vector2)mosca.position + randomDirection;

        // Teletransportar el objeto a la nueva posición
        EnemyPosition.transform.position = randomPosition;
    }

    void UpdateInternalCounterAndCooldown()
    {
        // Decrementar el contador interno
        contadorInterno -= Time.deltaTime;

        // Actualizar el enfriamiento de generación de enemigos en función del tiempo restante del contador interno
        if (contadorInterno > 0)
        {
            if (contadorInterno >= 110) //01:50min
            {
                enemySpawnCooldown = 18.0f; //01:32min
            }
            else if (contadorInterno >= 92) //01:20min
            {
                enemySpawnCooldown = 15.0f;//01:05min
            }
            else if (contadorInterno >= 77) //01:00min
            {
                enemySpawnCooldown = 12.0f;
            }
            else if (contadorInterno >= 50) //00:50min
            {
                enemySpawnCooldown = 8.0f;
            }
            else if (contadorInterno >= 40) //00:40min
            {
                enemySpawnCooldown = 5.0f;
            }
            else if (contadorInterno >= 30) //00:30min
            {
                enemySpawnCooldown = 3.0f;
            }
            else if (contadorInterno >= 20) //00:20min
            {
                enemySpawnCooldown = 3.0f;
            }
            else if (contadorInterno >= 10) //00:10min
            {
                enemySpawnCooldown = 1.0f;
            }
        }
    }
}