using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public float duracionTotal = 120.0f; // Duración total del contador en segundos (2 minutos)
    public float intensidadTemblorInicial = 0.1f; 
    public float intensidadTemblorFinal = 0.3f; 
    private float tiempoRestante; 

    private TextMeshProUGUI textoContador; 
    private Vector2 posicionOriginal; 
    private bool countdownStarted = false; 

    void Start()
    {
        
        textoContador = GetComponent<TextMeshProUGUI>();

        
        posicionOriginal = textoContador.rectTransform.anchoredPosition;

        
        tiempoRestante = duracionTotal;
    }

    void Update()
    {
        // Verificar si se ha presionado la tecla "W" para comenzar el contador
        if (Input.GetKeyDown(KeyCode.W))
        {
            countdownStarted = true; // Iniciar la cuenta regresiva
        }

        
        if (countdownStarted)
        {
            
            tiempoRestante -= Time.deltaTime;

            
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            int milisegundos = Mathf.FloorToInt((tiempoRestante * 100) % 100);

            
            textoContador.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);

            
            float proporcion = tiempoRestante / duracionTotal;
            float intensidadTemblor = Mathf.Lerp(intensidadTemblorInicial, intensidadTemblorFinal, 1f - proporcion);

            
            textoContador.rectTransform.anchoredPosition = posicionOriginal + Random.insideUnitCircle * intensidadTemblor;

            
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                // Cambiar a la escena "GameOver"
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}