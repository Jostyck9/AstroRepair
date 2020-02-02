using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class TimeLeaderboard : MonoBehaviour
{
    public Text textTimes;

    private string display;
    // Start is called before the first frame update
    void Start()
    {
        Leaderboard lead = new Leaderboard();
        lead.FillInListAndStrings();
        display = lead.getTimes();
    }

    // Update is called once per frame
    void Update()
    {
        textTimes.text = display;
    }

}
