using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogCanvas; // Asigna el Canvas en el Inspector
    public float displayInterval = 10.0f; // Intervalo de tiempo para mostrar el Canvas

    private float timer;

    void Start()
    {
        // Inicia el temporizador
        timer = displayInterval;
    }

    void Update()
    {
        // Actualiza el temporizador si el Canvas está desactivado
        if (!dialogCanvas.activeSelf)
        {
            timer -= Time.deltaTime;

            // Verifica si el temporizador ha llegado a cero
            if (timer <= 0)
            {
                // Muestra el Canvas
                dialogCanvas.SetActive(true);
                Debug.Log("Canvas Activado");

                // Reinicia el temporizador
                timer = displayInterval;
            }
        }

        // Verifica si se presiona la tecla SPACE y el Canvas está activo
        if (Input.GetKeyDown(KeyCode.Space) && dialogCanvas.activeSelf)
        {
            // Oculta el Canvas
            dialogCanvas.SetActive(false);
            Debug.Log("Canvas Desactivado");
        }
    }
}