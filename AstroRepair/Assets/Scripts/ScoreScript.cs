using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float time = 0;
    public static float lastTime = 0;

    public uint pieces = 0;
    public static uint lastPieces = 0;

    public bool startTimeScore = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeScore)
        {
            time += Time.deltaTime;
            lastTime = time;
            lastPieces = pieces;
        }
    }

    public uint getLastPieces()
    {
        return lastPieces;
    }

    public float getLastTime()
    {
        return lastTime;
    }

    public void startScore()
    {
        startTimeScore = true;
    }
}
