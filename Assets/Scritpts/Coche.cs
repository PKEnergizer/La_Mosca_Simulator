using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    public GameObject mosca; // Referencia al GameObject de la mosca
    public GameObject coche; // Referencia al GameObject del coche
    public Collider2D colliderCarretera; // Collider de la carretera

    private Animator cocheAnimator; // Referencia al Animator del coche
    private bool moscaEnCarretera = false; // Variable para controlar si la mosca está en la carretera

    void Start()
    {
        cocheAnimator = coche.GetComponent<Animator>(); // Obtener el Animator del coche
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == mosca && other.IsTouching(colliderCarretera))
        {
            moscaEnCarretera = true; // La mosca está en la carretera
            Debug.Log("ACTIVA ANIMATOR COCHE");
            cocheAnimator.SetTrigger("EnCarretera");
        }
    }

}