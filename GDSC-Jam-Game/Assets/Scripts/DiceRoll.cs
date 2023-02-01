using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice{
    public int value;
    public Dice(){
        this.value = Random.Range(0,6);
        Debug.Log("Dice created with value: " + (value + 1));
    }
}
public class DiceRoll : MonoBehaviour
{
    public Animator animator;
    public int result;
    void Awake() {
        animator = GetComponent<Animator>();
    }

    public int Roll()
    {    
        Dice dice = new Dice();
        animator.SetTrigger("roll");
        animator.SetInteger("index", dice.value);
        animator.SetTrigger("roll2");
        return dice.value+1;
    }
}
