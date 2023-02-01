using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public string newText{get; private set; }
    public Button button;
    

    private void Awake()
    {
        newText = button.GetComponentInChildren<TMP_Text>().text;
    }
}
