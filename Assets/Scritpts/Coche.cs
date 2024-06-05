using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    public GameObject mosca; 
    public GameObject coche; 
    public Collider2D colliderCarretera; 

    private Animator cocheAnimator; 
    private bool moscaEnCarretera = false; 

    void Start()
    {
        cocheAnimator = coche.GetComponent<Animator>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == mosca && other.IsTouching(colliderCarretera))
        {
            moscaEnCarretera = true; 
            Debug.Log("ACTIVA ANIMATOR COCHE");
            cocheAnimator.SetTrigger("EnCarretera");
        }
    }

}