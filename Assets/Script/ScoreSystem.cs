using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreSystem : MonoBehaviour
{
   public static ScoreSystem instance;
   public TMP_Text PacDotText;
   public static int dots=0;



   void Update()
   {
      PacDotText.text = "Dots: "+dots.ToString();
   }

}
