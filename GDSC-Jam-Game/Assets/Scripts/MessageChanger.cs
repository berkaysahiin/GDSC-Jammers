using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class MessageChanger : MonoBehaviour
{

    [SerializeField] private TMP_Text textMessage;
    [SerializeField] private List<Button> buttons = new List<Button>();
    public string initial;
    private MessageManager _messageManager;
    private void Awake()
    {
        initial = textMessage.text;
    }
    public void ChangeText()
    {
        var s = EventSystem.current.currentSelectedGameObject.GetComponent<MessageManager>().newText;
        textMessage.text = s;
    }

    public void Reload()
    {
        textMessage.text = initial;
    }
}

