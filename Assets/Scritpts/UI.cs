using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image puntero; 

    void Start()
    {
        
        Cursor.visible = false;
    }

    void Update()
    {
        
        Vector3 posicionRaton = Input.mousePosition;

        
        Vector3 posicionEnMundo = Camera.main.ScreenToWorldPoint(posicionRaton);
        posicionEnMundo.z = 0f; 

        
        puntero.transform.position = posicionEnMundo;
    }
}