using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGeneration : MonoBehaviour
{
    public TileBase sol1;
    public TileBase sol2;
    public TileBase sol3;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                int s = Random.Range(0, 2);
               if (s == 1)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), sol2);
                else
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), sol3);
            }
        }
        this.GetComponent<Tilemap>().RefreshAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
