using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsPanelUI;
   
    //[SerializeField]private TweenUi _tweenUi;
    //[SerializeField] private RectTransform[] buttons = new RectTransform[3];
    //[SerializeField] private float revealDuration = 2f;
    //[SerializeField] private GameObject target;
    //[SerializeField] private RectTransform button;
    private void Start()
    {
        optionsPanelUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //_tweenUi.slidingButton();
            //slidingButton();
            if (GameIsPaused)
            {
                Resume(); 
                optionsPanelUI.SetActive(false);
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("OmarMainMenu");
        
    }

    public void slidingButton()
    {
        //foreach (RectTransform button in buttons)
        //{
            //button.DOAnchorPosX(target.transform.position.x, revealDuration).From();
        //}
    }
}
