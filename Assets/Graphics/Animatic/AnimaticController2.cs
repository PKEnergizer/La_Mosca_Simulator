using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AnimaticController2 : MonoBehaviour
{
    public GameObject[] panels; // Array de paneles
    public string[] dialogues;  // Array de diálogos correspondientes
    public TextMeshProUGUI dialogueText; // Referencia al TextMeshPro en el panel de diálogo
    public float typingSpeed = 0.05f; // Velocidad de aparición de las letras

    private int currentPanelIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        ShowCurrentPanel();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isTyping)
        {
            NextPanel();
        }
    }

    void ShowCurrentPanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == currentPanelIndex);
        }
        StartCoroutine(TypeDialogue(dialogues[currentPanelIndex]));
    }

    void NextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)
        {
            currentPanelIndex++;
            ShowCurrentPanel();
        }
        else
        {
            // Cambiar a la siguiente escena
            SceneManager.LoadScene("Menu_Inicial");
        }
    }

    IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}