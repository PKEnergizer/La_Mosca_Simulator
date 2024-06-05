using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuertaArriba : MonoBehaviour
{
    public Animator puertaAnimator;
    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca"))
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