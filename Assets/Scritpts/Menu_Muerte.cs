using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Muerte : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 10f;
    private float countdownTimer;

    // Referencias a los botones
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        countdownTimer = countdownDuration;
        
        retryButton.onClick.AddListener(Retry);
        quitButton.onClick.AddListener(Quit);
    }

    void Update()
    {
        countdownTimer -= Time.deltaTime;

        int seconds = Mathf.RoundToInt(countdownTimer);
        countdownText.text = seconds.ToString();

    
        if (countdownTimer <= 0)
        {
            SceneManager.LoadScene("Menu_Inicial");
        }
    }

    public void Retry()
    {
        // Reiniciar las vidas a 5
        GameManager.Instance.RestablecerVidas();
        SceneManager.LoadScene("LvL_1");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu_Inicial");
    }
}