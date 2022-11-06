using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinLose : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text Result;
    void Start()
    {
        if (Remaining_Dots.remaining_dots == 0 && ScoreSystem.dots > 0) 
        {
            Result.text = "You " + "win!";
        } else 
        {
            Result.text = "You " + "lose!";
        }
    }
}


