using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburguesa : MonoBehaviour

    
{
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntuacion puntaje;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca")){

            puntaje.SumarPuntos(cantidadPuntos);
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
