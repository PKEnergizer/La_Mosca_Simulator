using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mosca"))
        {
            // Si la mosca entra en contacto con el collider del mapa,
            // la reposicionamos a una posición segura (por ejemplo, la posición inicial)
            other.transform.position = new Vector3(0f, 0f, 0f); // Cambia esto por la posición deseada
        }
    }
}