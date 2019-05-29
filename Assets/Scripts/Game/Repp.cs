using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Repp : MonoBehaviour
{
    public float difficultyMultiplier = 0.5f;
    public static float Rep { get; private set; }
    public readonly float maxRep = 100;
    public TextMeshProUGUI text;

    private static Repp repScript;

    private void Awake()
    {
        text.text = "Rep: " + ((int)Rep).ToString();
        repScript = this;
    }

    public static void changeRep(float amount)
    {


        amount += (float)MainMenuHandler.difficulty * repScript.difficultyMultiplier;

        Rep += amount;
        if (Rep > repScript.maxRep)
        {
            Rep = repScript.maxRep;
        }
        else if (Rep < 0)
        {
            Rep = 0;
        }
        repScript.text.text = "Rep: " + ((int)Rep).ToString();
    }
}
