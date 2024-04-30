using UnityEngine;
using System.Collections;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public AudioClip letterSound;
    public float letterInterval = 0.05f; // Intervalo entre la aparición de cada letra

    private string currentDialog;
    private int currentLetterIndex;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Verificar si se presiona la tecla SPACE para mostrar el diálogo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLetterIndex = 0; // Reiniciar el índice de letras
            StartCoroutine(ShowDialog("Este es un ejemplo de diálogo letra por letra.", letterInterval));
        }
    }

    IEnumerator ShowDialog(string dialog, float interval)
    {
        currentDialog = dialog;
        dialogText.text = "";

        // Mostrar una letra cada frame
        while (currentLetterIndex < currentDialog.Length)
        {
            dialogText.text += currentDialog[currentLetterIndex];
            currentLetterIndex++;

            // Reproducir el sonido de la letra
            PlayLetterSound();

            yield return new WaitForSeconds(interval);
        }
    }

    void PlayLetterSound()
    {
        if (letterSound != null)
        {
            audioSource.PlayOneShot(letterSound);
        }
    }
}