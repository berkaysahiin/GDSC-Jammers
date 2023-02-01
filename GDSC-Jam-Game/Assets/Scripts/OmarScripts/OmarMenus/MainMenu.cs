using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playPopOut;
    private string levelToLoad;
    //[SerializeField] private GameObject noSavedGameText = null;
    public GameObject noSavedData;
    public void Start()
    {
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
    
}
