using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreEndMenu : MonoBehaviour
{
    public ScoreScript scoreSave;
    public Text textScore;
    string display;
    void Start()
    {
        display = "Final score:\n" + (int)scoreSave.getLastTime() + " seconds with " + scoreSave.getLastPieces() + " pieces";
    }

    void Update()
    {
        textScore.text = display;
    }
}
