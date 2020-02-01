using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Leaderboard : MonoBehaviour
{
    public Text textNames;
    public Text textTimes;
    public Text textPieces;

    List<Player> interm = new List<Player>();
    List<Player> sorted;

    string path, jsonString;
    string names = "";
    string times = "";
    string pieces = "";

    void Start()
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
                names += (player.name + "\n");
                times += (player.time + "\n");
                pieces += (player.pieces + "\n");
            }
            count++;
        });
    }
    // Update is called once per frame
    void Update()
    {
        textNames.text = names;
        textTimes.text = times;
        textPieces.text = pieces;
    }
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
