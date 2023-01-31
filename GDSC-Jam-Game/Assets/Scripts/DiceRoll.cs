using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice{
    public int sides;
    public int value;
    public Dice(int sides){
        this.sides = sides;
    }
    public int Roll(){
        value = Random.Range(1, sides + 1);
        return value;
    }
}

public class DiceRoll
{
    public List<Dice> dice;
    public DiceRoll(){
        dice = new List<Dice>();
    }
    public void AddDice(int sides){
        dice.Add(new Dice(sides));
    }
    public void Roll(){
        for(int i = 0; i < dice.Count; i++){
            dice[i].Roll();
        }
    }

    public int TotalValue(){
        int total = 0;
        for(int i = 0; i < dice.Count; i++){
            total += dice[i].value;
        }
        return total;
    }
}
