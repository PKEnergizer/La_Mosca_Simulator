using UnityEngine;
using UnityEngine.UI;

public class StartControls : MonoBehaviour
{
    public GameObject buttonObject; 

    private bool isButtonVisible = true; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            Destroy(gameObject);
        }

        
        FlashButton();
    }

    void FlashButton()
    {
        
        if (buttonObject != null)
        {
            
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