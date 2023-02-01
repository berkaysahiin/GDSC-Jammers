using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRollTest : MonoBehaviour
{
    private DiceRoll[] _dices;
    [SerializeField] private TMP_Text diceTotal;

    private void Awake() 
    {
        _dices = GetComponentsInChildren<DiceRoll>();
    }
    
    private void Start() 
    {
        SetDicesActive(false);
    }

    private int Roll(){
        diceTotal.gameObject.SetActive(true);
        SetDicesActive(true);

        int sum = 0;
        foreach(DiceRoll dice in _dices){
            sum += dice.Roll();
        }
        //totalvalue animasyondan önce display ediliyor
        diceTotal.text = sum.ToString();

        return sum;
    }

    private void SetDicesActive(bool flag)
    {
        foreach(var dice in _dices) 
        {
            dice.gameObject.SetActive(flag);
        }

    }
    
    public void Trigger() 
    {
        this.Roll();
    }
}