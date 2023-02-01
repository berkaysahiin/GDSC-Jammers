using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
   public string name;
   [TextArea(3, 10)]
   public string[] sentences;

   public Dialogue(string[] sentences)
   {
      this.sentences = sentences;
   }
}
