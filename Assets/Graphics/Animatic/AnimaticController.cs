using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AnimaticController : MonoBehaviour
{
    public GameObject[] panels; 
    public string[] dialogues;  
    public TextMeshProUGUI dialogueText; 
    public float typingSpeed = 0.05f;

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
            SceneManager.LoadScene("LvL_1");
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