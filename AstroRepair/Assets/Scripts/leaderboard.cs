using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Leaderboard
{
/*    public Text textNames, textTimes, textPieces;
*/
    List<Player> interm = new List<Player>(), sorted;

    string path, jsonString, names, times, pieces;

    public void FillInListAndStrings()
    {
        path = Application.streamingAssetsPath + "/leaderboard.json";
        jsonString = File.ReadAllText(path);

        Players myList = JsonUtility.FromJson<Players>(jsonString);
        foreach (Player player in myList.players)
        {
            interm.Add(player);
        }
        sorted = interm.OrderByDescending(player => player.pieces).ThenBy(player => player.time).ToList();
        int count = 0;
        names += "Name\n";
        times += "Time\n";
        pieces += "Ship Parts\n";
        sorted.ForEach(player => {
            if (count <= 4)
            {
                names += ((count + 1) + " " + player.name + "\n");
                times += (player.time + "\n");
                pieces += (player.pieces + "\n");
            }
            count++;
        });
    }

    public string getNames()
    {
        return (names);
    }
    public string getTimes()
    {
        return (times);
    }
    public string getPieces()
    {
        return (pieces);
    }

/*    void Start()
    { 
    
    }
    // Update is called once per frame
    void Update()
    {
        textNames.text = names;
        textTimes.text = times;
        textPieces.text = pieces;
    }*/
}

[System.Serializable]
public class Player
{
    public string name;
    public string time;
    public int pieces;
}

[System.Serializable]
public class Players
{
    public Player[] players;
}
