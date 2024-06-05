using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuerta : MonoBehaviour

{
    public Animator puertaAnimator;
    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca")|| other.CompareTag("Jerry"))
        {
            if (puertaAbierta)
            {
                puertaAnimator.SetBool("Abierta", false);
            }
            else
            {
                puertaAnimator.SetBool("Abierta", true);
            }
            puertaAbierta = !puertaAbierta;
        }
    }
}