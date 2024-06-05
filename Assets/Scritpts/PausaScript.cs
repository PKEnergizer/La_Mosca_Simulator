using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PausaScript : MonoBehaviour
{
    
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject menuOpciones;
    
    void Start()
    {
        //menuPausa = GameObject.Find("PanelPausa");
        //menuOpciones = GameObject.Find("PanelOpciones");
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
    }

    void Update()
    {
 Pausar();
    }

     public void Pausar()
    {
        //menuPausa = GameObject.Find("PanelPausa");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausado");
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }else{
            Debug.Log("No pausado");
        }
    }
    
    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void showOpciones()
    {
        menuOpciones.SetActive(true);
    }

    public void hideOpciones()
    {
        menuOpciones.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("He salido");
        Application.Quit();
    }
}
