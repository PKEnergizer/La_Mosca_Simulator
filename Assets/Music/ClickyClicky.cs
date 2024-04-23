using UnityEngine;

public class ClickyClicky : MonoBehaviour
{
    public AudioClip clickSound; // Sonido que se reproducirá al hacer clic en la imagen
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}