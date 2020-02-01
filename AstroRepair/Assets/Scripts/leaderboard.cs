using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Leaderboard : MonoBehaviour
{
    public Text myText;
    string path, jsonString;
    List<Player> interm = new List<Player>();
    List<Player> sorted;
    string display;
    List<string> names;
    List<string> time;
    List<string> pieces;

    void Start()
    {
        path = Application.streamingAssetsPath + "/leaderboard.json";
        jsonString = File.ReadAllText(path);

        Players myList = JsonUtility.FromJson<Players>(jsonString);
        foreach (Player player in myList.players)
        {
            interm.Add(player);
        }
        this.sorted = interm.OrderByDescending(player => player.pieces).ThenBy(player => player.time).ToList<Player>();
        int count = 0;
        display += "Name\t\tTime\t\tShip Pieces\n";
        this.sorted.ForEach(player => {
            if (count <= 4)
            {
                display += player.name + "\t\t" + player.time + "\t\t" + player.pieces + "\n";
            }
            count++;
        });
    }
    // Update is called once per frame
    void Update()
    {
        myText.text = display;
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
