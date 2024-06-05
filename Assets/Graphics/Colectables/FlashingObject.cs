using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObject : MonoBehaviour
{
    public float flashDuration = 1.0f; // Duración de un ciclo completo (aumento y disminución de brillo)
    public Color flashColor = Color.yellow; // Color del brillo
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private Color originalColor; // Color original del sprite

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un componente SpriteRenderer en el objeto.");
            return;
        }

        originalColor = spriteRenderer.color;

      
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        while (true)
        {
            // Aumentar el brillo
            yield return StartCoroutine(ChangeColor(originalColor, flashColor, flashDuration / 2));
            // Disminuir el brillo
            yield return StartCoroutine(ChangeColor(flashColor, originalColor, flashDuration / 2));
        }
    }

    IEnumerator ChangeColor(Color startColor, Color endColor, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = endColor;
    }
}