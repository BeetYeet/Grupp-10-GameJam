using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Repp : MonoBehaviour
{
    public float difficultyMultiplier = 0.5f;
    public float Rep { get; private set; }
    public readonly float maxRep = 100;
    public TextMeshProUGUI text;


    private void Awake()
    {
        text.text = "Rep: " + ((int)Rep).ToString();
    }

    void changeRep(float amount)
    {


        amount += (float)MainMenuHandler.difficulty * difficultyMultiplier;

        Rep += amount;
        if (Rep > maxRep)
        {
            Rep = maxRep;
        }
        else if (Rep < 0)
        {
            Rep = 0;
        }
        text.text = "Rep: " + ((int)Rep).ToString();
    }
}
