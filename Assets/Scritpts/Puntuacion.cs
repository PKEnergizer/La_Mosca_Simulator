using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float puntos;
    private Vector2 posicionOriginal; // Posición original del texto

    // Variables para el temblor del texto
    public float intensidadTemblor = 0.1f; // Intensidad inicial del temblor
    public float duracionTemblor = 0.2f; // Duración del temblor al sumar puntos
    private float tiempoInicioTemblor; // Tiempo en que comenzó el temblor

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        // Guardar la posición original del texto
        posicionOriginal = textMesh.rectTransform.anchoredPosition;
    }

    void Update()
    {
        textMesh.text = puntos.ToString("0");

        // Aplicar temblor si ha pasado el tiempo de duración del temblor
        if (Time.time - tiempoInicioTemblor < duracionTemblor)
        {
            float offsetX = Random.Range(-intensidadTemblor, intensidadTemblor);
            float offsetY = Random.Range(-intensidadTemblor, intensidadTemblor);
            Vector2 nuevaPosicion = posicionOriginal + new Vector2(offsetX, offsetY);
            textMesh.rectTransform.anchoredPosition = nuevaPosicion;
        }
        else
        {
            // Restaurar la posición original del texto al finalizar el temblor
            textMesh.rectTransform.anchoredPosition = posicionOriginal;
        }
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        tiempoInicioTemblor = Time.time; // Registrar el tiempo de inicio del temblor
    }
}