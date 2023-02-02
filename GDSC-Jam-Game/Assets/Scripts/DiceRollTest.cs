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


    public void Roll(){
        diceTotal.gameObject.SetActive(false);

        int sum = 0;
        foreach(DiceRoll dice in _dices){
            sum += dice.Roll();
        }
        //totalvalue animasyondan önce display ediliyor
        diceTotal.text = sum.ToString();

        StartCoroutine(Wait());

    }

    IEnumerator Wait(){
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSecondsRealtime(2f);
        diceTotal.gameObject.SetActive(true);

    }
}