using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   public static DialogueTrigger instance = null;

   private DialogueManager dialogueManager;

   private DialogueTrigger() {}


   public void Awake() 
   {
      dialogueManager = FindObjectOfType<DialogueManager>();

      if(instance is null) {
         instance = this;
      }
      else if(instance != this) {
         Destroy(this.gameObject);
      }
   }
   
   public void TriggerDialogue(Dialogue dialogue)
   {
      dialogueManager.StartDialogue(dialogue);
   }
}
