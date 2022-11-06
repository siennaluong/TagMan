using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Remaining_Dots : MonoBehaviour
{
    public static Remaining_Dots instance;
    public TMP_Text Remaining;
    public static int remaining_dots;

    public AudioSource background;

    void Start()
    {
        background.Play();
        Remaining.text = "Uncollected: " + remaining_dots.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Remaining.text = "Uncollected: " + remaining_dots.ToString();
    }
}
