using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Muerte : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 10f;
    private float countdownTimer;

    // Referencias a los botones
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        countdownTimer = countdownDuration;

        // Asignar los métodos a los botones
        retryButton.onClick.AddListener(Retry);
        quitButton.onClick.AddListener(Quit);
    }

    void Update()
    {
        countdownTimer -= Time.deltaTime;

        // Actualizar el texto de la cuenta regresiva
        int seconds = Mathf.RoundToInt(countdownTimer);
        countdownText.text = seconds.ToString();

        // Verificar si el contador ha llegado a cero
        if (countdownTimer <= 0)
        {
            // Redirigir a la escena "Menu_Inicial"
            SceneManager.LoadScene("Menu_Inicial");
        }
    }

    // Método para el botón "Reintentar"
    public void Retry()
    {
        SceneManager.LoadScene("LvL_1");
    }

    // Método para el botón "Salir"
    public void Quit()
    {
        SceneManager.LoadScene("Menu_Inicial");
    }
}