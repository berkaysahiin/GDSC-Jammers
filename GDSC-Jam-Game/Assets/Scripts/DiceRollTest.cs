using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRollTest : MonoBehaviour
{

    [SerializeField] private DiceRoll[] dices;
    [SerializeField] private TMP_Text diceTotal;


    public void Roll(){
        int sum = 0;
        foreach(DiceRoll dice in dices){
            sum += dice.Roll();
        }
        //totalvalue animasyondan önce display ediliyor
        StartCoroutine(Wait());
        diceTotal.text = sum.ToString();
        
    }
    IEnumerator Wait(){
        yield return new WaitForSecondsRealtime(3);
    }
}