using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuerta : MonoBehaviour

{
    public Animator puertaAnimator;
    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca"))
        {
            if (puertaAbierta)
            {
                // Si la puerta está abierta, activa la animación de "cerrándose"
                puertaAnimator.SetBool("Abierta", false);
            }
            else
            {
                // Si la puerta está cerrada, activa la animación de "abriéndose"
                puertaAnimator.SetBool("Abierta", true);
            }
            // Invierte el estado de la puerta
            puertaAbierta = !puertaAbierta;
        }
    }
}