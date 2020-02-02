using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ShipPiecePlayer pieces;
    public AirManager aManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (pieces.maxPieces == pieces.nbrPieces - pieces.currentOnPlayer)
        {
            Debug.Log("Won");
            Application.Quit();
        } else if (aManager.currentAir <= 0)
        {
            Debug.Log("Loose");
            Application.Quit();
        }
    }
}
