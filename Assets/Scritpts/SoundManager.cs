using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumenSlider;
    

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
             PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }else{
            Load();
        }
       
    }

    public void ChangeVolumen()
    {
        AudioListener.volume = volumenSlider.value;
        Save();
    }

    private void Load()
    {
        volumenSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumenSlider.value);
    }
}
