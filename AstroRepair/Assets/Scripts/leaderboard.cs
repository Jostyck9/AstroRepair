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

    void Start()
    {
        path = Application.streamingAssetsPath + "/leaderboard.json";
        jsonString = File.ReadAllText(path);

        Players myList = JsonUtility.FromJson<Players>(jsonString);
        foreach (Player player in myList.players)
        {
            interm.Add(player);
        }
/*        this.interm.ForEach(player => { Debug.Log("info: " + player.name); });*/
        this.sorted = interm.OrderByDescending(player => player.pieces).ThenBy(player => player.time).ToList<Player>();
        /*.ThenBy(player => player.time)*/
        this.sorted.ForEach(player => { Debug.Log("info: " + player.name); });
        /*        sorted = interm.OrderBy(player => player.pieces);*/
    }
    // Update is called once per frame
    void Update()
    {
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
