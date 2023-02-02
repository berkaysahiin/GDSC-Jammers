using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiceRollTest : MonoBehaviour
{
    [SerializeField] private DiceRoll[] _dices;
    [SerializeField] private TMP_Text diceTotal;
    [SerializeField] private Canvas diceCanvas;

    public int result{get; private set;}

    void Start() 
    {
        diceCanvas.gameObject.SetActive(false);
    }

    public void Roll(){
        diceCanvas.gameObject.SetActive(true);
        diceTotal.gameObject.SetActive(false);

        int sum = 0;
        foreach(DiceRoll dice in _dices){
            sum += dice.Roll();
        }
        diceTotal.text = sum.ToString();
        result = sum;
        StartCoroutine(ActivateTotalNumber(2));
        StartCoroutine(DisableCanvas(3));
    }

    public void DisableCanvas()
    {
        diceCanvas.gameObject.SetActive(false);
    }

    IEnumerator ActivateTotalNumber(float time){
        yield return new WaitForSecondsRealtime(time);
        diceTotal.gameObject.SetActive(true);
    }
    IEnumerator DisableCanvas(float time){
        yield return new WaitForSecondsRealtime(time);
        diceCanvas.gameObject.SetActive(false);
    }
}