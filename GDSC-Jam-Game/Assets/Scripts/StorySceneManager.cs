using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneManager : MonoBehaviour
{
   private void OnEnable()
   {
      SceneManager.LoadScene("BerkayScene", LoadSceneMode.Single);
   }
}
