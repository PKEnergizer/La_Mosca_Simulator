using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPrincipal : MonoBehaviour
{
    // Nombre de las escenas
    public string nombreDeEscenaJuego = "AnimaticInicio";

    // Vibración
    private Vector3 posicionInicial;
    public float intensidadVibracion = 0.05f;
    public float velocidadVibracion = 10f;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void OnMouseDown()
    {
        // Verificar si el collider del objeto es el Jugar_button
        if (gameObject.name == "Jugar_button")
        {
            Jugar();
        }
        // Verificar si el collider del objeto es el salir_button
        else if (gameObject.name == "Salir_button")
        {
            Salir();
        }
        // Verificar si el collider del objeto es el opciones_button
        else if (gameObject.name == "Opciones_button")
        {
            Opciones();
        }
    }

    // Método para cambiar a la escena de juego
    public void Jugar()
    {
        SceneManager.LoadScene(nombreDeEscenaJuego);
    }

    // Método para cerrar la aplicación
    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    // Método para abrir el menú de opciones
    public void Opciones()
    {
        Debug.Log("Abrir menú de opciones...");
    }

    // Vibración del botón al pasar el puntero
    private void OnMouseEnter()
    {
        StartCoroutine(VibrarBoton());
    }

    private void OnMouseExit()
    {
        StopAllCoroutines();
        transform.position = posicionInicial;
    }

    IEnumerator VibrarBoton()
    {
        while (true)
        {
            float offsetX = Random.Range(-intensidadVibracion, intensidadVibracion);
            float offsetY = Random.Range(-intensidadVibracion, intensidadVibracion);

            Vector3 nuevaPosicion = posicionInicial + new Vector3(offsetX, offsetY, 0);
            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, Time.deltaTime * velocidadVibracion);

            yield return null;
        }
    }
}