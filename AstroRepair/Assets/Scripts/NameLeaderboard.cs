using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameLeaderboard : MonoBehaviour
{
    public Text textNames;

    private string display;
    // Start is called before the first frame update
    void Start()
    {
        Leaderboard lead = new Leaderboard();
        lead.FillInListAndStrings();
        display = lead.getNames();
    }

    // Update is called once per frame
    void Update()
    {
        textNames.text = display;
    }
}
