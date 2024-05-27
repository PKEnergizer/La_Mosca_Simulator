using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int vidas = 5;
    public static int puntos = 0;
    public static bool estoyMuerto = false;

    // Llamar a los GameObjects de las vidas
    GameObject heart5;
    GameObject heart4;
    GameObject heart3;
    GameObject heart2;
    GameObject heart1;
    // GameObject "textoPuntos"
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        heart5 = GameObject.Find("Corazon5");
        heart4 = GameObject.Find("Corazon4");
        heart3 = GameObject.Find("Corazon3");
        heart2 = GameObject.Find("Corazon2");
        heart1 = GameObject.Find("Corazon1");
    }

    void Update()
    {
        Debug.Log("Vidas: " + vidas);
    }

    // Cambiar el color de los corazones
    public void UpdateVidas()
    {
        switch(vidas)
        {
            case 4:
                heart5.GetComponent<Image>().color = Color.black;
                break;
            case 3:
                heart5.GetComponent<Image>().color = Color.black;
                heart4.GetComponent<Image>().color = Color.black;
                break;
            case 2:
                heart5.GetComponent<Image>().color = Color.black;
                heart4.GetComponent<Image>().color = Color.black;
                heart3.GetComponent<Image>().color = Color.black;
                break;
            case 1:
                heart5.GetComponent<Image>().color = Color.black;
                heart4.GetComponent<Image>().color = Color.black;
                heart3.GetComponent<Image>().color = Color.black;
                heart2.GetComponent<Image>().color = Color.black;
                break;
            case 0:
                heart5.GetComponent<Image>().color = Color.black;
                heart4.GetComponent<Image>().color = Color.black;
                heart3.GetComponent<Image>().color = Color.black;
                heart2.GetComponent<Image>().color = Color.black;
                heart1.GetComponent<Image>().color = Color.black;
                GameOver();
                break;
        }
    }

    void GameOver()
    {
        if (vidas == 0)
        {
            Debug.Log("He muerto");
            SceneManager.LoadScene("GameOver");
        }
    }
}