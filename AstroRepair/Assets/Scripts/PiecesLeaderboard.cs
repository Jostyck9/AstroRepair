using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PiecesLeaderboard : MonoBehaviour
{
    public Text textPieces;

    private string display;
    // Start is called before the first frame update
    void Start()
    {
        Leaderboard lead = new Leaderboard();
        lead.FillInListAndStrings();
        display = lead.getPieces();
    }

    // Update is called once per frame
    void Update()
    {
        textPieces.text = display;
    }
}
