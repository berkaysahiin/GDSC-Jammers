using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

public class EncounterManager : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public DiceRollTest diceRollTest;
    private Dictionary<FigureType, Dialogue>  dialogue = new Dictionary<FigureType, Dialogue>();
    private EncounterManager() {}
    public static EncounterManager instance = null;

    private void Awake()
    {
        if(instance is null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        diceRollTest = FindObjectOfType<DiceRollTest>();
    }

    public void Handle(Collider2D other, GameObject caller) {
        var other_figure = other.GetComponent<Figure>();
        var callerFigure = caller.GetComponent<Figure>();

        InteractionManager.instance.SignalPlayerStop();
        this.dialogueTrigger.TriggerDialogue(new Dialogue(new string[] {"hello"}));
    }
}
