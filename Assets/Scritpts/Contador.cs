using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public float duracionTotal = 120.0f; // Duración total del contador en segundos (2 minutos)
    public float intensidadTemblorInicial = 0.1f; // Intensidad inicial del temblor
    public float intensidadTemblorFinal = 0.3f; // Intensidad final del temblor cuando se acerca a 00:00:00
    private float tiempoRestante; // Tiempo restante en segundos

    private TextMeshProUGUI textoContador; // Referencia al componente TextMeshProUGUI
    private Vector2 posicionOriginal; // Posición original del texto
    private bool countdownStarted = false; // Variable para controlar si la cuenta regresiva ha comenzado

    void Start()
    {
        // Obtener la referencia al componente TextMeshProUGUI
        textoContador = GetComponent<TextMeshProUGUI>();

        // Guardar la posición original del texto
        posicionOriginal = textoContador.rectTransform.anchoredPosition;

        // No comenzar el contador hasta que se presione "W"
        tiempoRestante = duracionTotal;
    }

    void Update()
    {
        // Verificar si se ha presionado la tecla "W" para comenzar el contador
        if (Input.GetKeyDown(KeyCode.W))
        {
            countdownStarted = true; // Iniciar la cuenta regresiva
        }

        // Actualizar el tiempo restante solo si la cuenta regresiva ha comenzado
        if (countdownStarted)
        {
            // Actualizar el tiempo restante
            tiempoRestante -= Time.deltaTime;

            // Convertir el tiempo restante a minutos, segundos y milisegundos
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            int milisegundos = Mathf.FloorToInt((tiempoRestante * 100) % 100);

            // Actualizar el texto del contador
            textoContador.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);

            // Calcular la intensidad del temblor en función del tiempo restante
            float proporcion = tiempoRestante / duracionTotal;
            float intensidadTemblor = Mathf.Lerp(intensidadTemblorInicial, intensidadTemblorFinal, 1f - proporcion);

            // Aplicar el temblor como una modificación adicional a la posición original
            textoContador.rectTransform.anchoredPosition = posicionOriginal + Random.insideUnitCircle * intensidadTemblor;

            // Detener el contador cuando el tiempo restante llegue a cero
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                // Cambiar a la escena "GameOver"
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}