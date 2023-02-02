using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

public class EncounterManager : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    [HideInInspector] public DiceRollTest diceRollTest;
    private Dictionary<FigureType, Dialogue>  dialogues = new Dictionary<FigureType, Dialogue>();
    private EncounterManager() {}
    [SerializeField] private Canvas messageChanger;
    public static EncounterManager instance = null;

    private Figure otherFigure = null;
    private Figure callerFigure = null;


    private void Awake()
    {
        if(instance is null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(this.gameObject);
        }

        dialogues.Add(FigureType.EnemyBird, new Dialogue(new string[] {"Hey", "What are you doing ?", "Do not touch to my message!"}));
        dialogues.Add(FigureType.Soldier, new Dialogue(new string[] {"Hey", "Where do you think you are going"}));
        dialogues.Add(FigureType.Castle, new Dialogue(new string[] {" \"Huge castle..\" "}));
    }

    private void Start() 
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        diceRollTest = FindObjectOfType<DiceRollTest>();
    }

    public void Handle(Collider2D other, GameObject caller) {
        if(InteractionManager.instance.allowed == false) return;

        otherFigure = other.GetComponent<Figure>();
        callerFigure = caller.GetComponent<Figure>();

        if(otherFigure.GetFigureType() == FigureType.Player) {
            Figure temp = otherFigure;
            otherFigure = callerFigure;
            callerFigure = temp;
        }

        if(callerFigure.GetFigureType() == FigureType.Player) {


            switch(otherFigure.GetFigureType())
            {
                case FigureType.EnemyBird:
                {
                    InteractionManager.instance.SignalPlayerStop();
                    otherFigure.PausePath();
                    this.dialogueTrigger.TriggerDialogue(dialogues[otherFigure.GetFigureType()]);
                    break;
                }
                case FigureType.Soldier:
                {
                    InteractionManager.instance.SignalPlayerStop();
                    this.dialogueTrigger.TriggerDialogue(dialogues[otherFigure.GetFigureType()]);
                    break;
                }
            }
        }
        else if(callerFigure.GetFigureType() == FigureType.EnemyBird)
        {
            switch(otherFigure.GetFigureType())
            {
                case FigureType.Castle:
                {

                    if(callerFigure.GetComponent<Message>().changed) 
                    {
                        callerFigure.DecreasePower();
                        otherFigure.DecreasePower();
                        Debug.Log("Castle enemybird but message changed");
                    }
                    else
                    {
                        Debug.Log("Castle enemybird message is correct");
                        callerFigure.IncreasePower();
                        otherFigure.IncreasePower();
                    }
                    break;
                }
                case FigureType.EnemyBird:
                {
                    callerFigure.IncreasePower();
                    otherFigure.IncreasePower();
                    Debug.Log("Enemybird enemybird");
                    break;
                }
                case FigureType.Soldier:
                {
                    callerFigure.IncreasePower();
                    otherFigure.IncreasePower();
                    Debug.Log("Enemybird soldier");
                    break;
                }
            }
        }
    }

    public IEnumerator InvokeRoll()
    {
        this.diceRollTest.Roll();

        if(callerFigure.GetPower() + diceRollTest.result < otherFigure.GetPower()) 
        {
            Debug.Log("Failed");
        }
        else {
            Debug.Log("Success");
            yield return new WaitForSecondsRealtime(4);

            if(otherFigure.GetFigureType() == FigureType.EnemyBird && callerFigure.GetFigureType() == FigureType.Player)
            {
                print(otherFigure.GetFigureType());
                InteractionManager.instance.SignalPlayerStop();
                this.messageChanger.gameObject.SetActive(true);
            }
        }
    }


    public void ChangeMessage()
    {
        InteractionManager.instance.RelasePlayerStop_s();
        otherFigure.GetComponent<Message>().changed = true;
        otherFigure.ContinuePath();
        Debug.Log("message changed");
        this.messageChanger.gameObject.SetActive(false);
    }
}
