using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaScript : MonoBehaviour
{
    private bool estoyMuerto = false;
    private bool isInvulnerable = false;
    private CapsuleCollider2D capCol;
    private SpriteRenderer spriteRenderer;
    public float invulnerabilityDuration = 4f;
    public float flashInterval = 0.2f;

    // Objeto a activar en el inspector
    public GameObject objetoAActivar;

    // Lista de tags requeridos
    private HashSet<string> requiredTags = new HashSet<string> { "Hamburguesa", "Kebab", "Pizza", "Cereales", "Chees" };
    // Lista de tags tocados
    private HashSet<string> touchedTags = new HashSet<string>();

    void Start()
    {
        capCol = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.Instance.vidas <= 0)
        {
            GameManager.estoyMuerto = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && !isInvulnerable)
        {
            GameManager.Instance.vidas -= 1;
            GameManager.Instance.UpdateVidas();

            if (GameManager.Instance.vidas > 0)
            {
                StartCoroutine(InvulnerabilityCooldown());
            }
        }
        else if (col.gameObject.tag == "Coche")
        {
            GameManager.Instance.vidas -= 5;
            GameManager.Instance.UpdateVidas();

            if (GameManager.Instance.vidas > 0)
            {
                StartCoroutine(InvulnerabilityCooldown());
            }
        }
        else if (requiredTags.Contains(col.gameObject.tag))
        {
            // Añadir el tag a la lista de tocados si es uno de los requeridos
            touchedTags.Add(col.gameObject.tag);

            // Verificar si todos los tags requeridos han sido tocados
            if (touchedTags.Count == requiredTags.Count)
            {
                // Activar el objeto asignado en el inspector
                if (objetoAActivar != null)
                {
                    objetoAActivar.SetActive(true);
                }
            }
        }
    }

    IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        float elapsedTime = 0f;

        while (elapsedTime < invulnerabilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
            elapsedTime += flashInterval;
        }

        spriteRenderer.enabled = true;
        isInvulnerable = false;
    }
}