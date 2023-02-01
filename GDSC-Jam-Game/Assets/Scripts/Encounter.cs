using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        EncounterManager.instance.Handle(other, this.gameObject);
    }
}
