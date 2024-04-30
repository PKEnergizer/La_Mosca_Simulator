using UnityEngine;
using UnityEngine.UI;

public class StartControls : MonoBehaviour
{
    public GameObject buttonObject; // Referencia al objeto Button dentro del Canvas

    private bool isButtonVisible = true; // Variable para controlar la visibilidad del botón

    // Update is called once per frame
    void Update()
    {
        // Verificar si se presiona la tecla "W"
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Destruir este objeto Canvas
            Destroy(gameObject);
        }

        // Hacer que el botón parpadee
        FlashButton();
    }

    void FlashButton()
    {
        // Verificar si el botón debe parpadear
        if (buttonObject != null)
        {
            // Alternar la visibilidad del botón cada cierto tiempo
            float blinkInterval = 1f; // Intervalo de parpadeo en segundos

            if (Time.time % blinkInterval < blinkInterval / 2)
            {
                // Mostrar el botón
                buttonObject.SetActive(isButtonVisible);
            }
            else
            {
                // Ocultar el botón
                buttonObject.SetActive(!isButtonVisible);
            }
        }
    }
}