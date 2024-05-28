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