using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreEndMenu : MonoBehaviour
{
    public Text textScore;
    string time, pieces, display;
    void Start()
    {
        /*        time = getTime().toString();*/
        /*        pieces = getPieces().soString();*/
        display = "Final score:\n" + time + " seconds for a score of: " + pieces;
    }

    void Update()
    {
        textScore.text = display;
    }
}
