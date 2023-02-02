using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UIElements.Slider;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playPopOut;
    private string levelToLoad;
    //[SerializeField] private GameObject noSavedGameText = null;
    public GameObject noSavedData;
    public GameObject credits;
    
    [Header("VolumeSettings")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    
    
    public void Start()
    {
        credits.SetActive(false);
        noSavedData.SetActive(false);
        playPopOut.SetActive(false);
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public static void newGamePlay()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void getSave()
    {
        //PlayerPrefs.GetString("SavedGame",yourLavelIs);
    }

    public void loadGamePlay()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            noSavedData.SetActive(true);
            //noSavedGameText.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
        
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        
    }
    
}
