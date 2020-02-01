using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGeneration : MonoBehaviour
{
    public TileBase sol1;
    public TileBase sol2;
    public TileBase bush1;
    public TileBase bush2;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                int s = Random.Range(0, 10);
                if (s == 1)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), bush1);
                else if (s == 2)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), bush2);
                else if (s > 2 && s <= 6)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), sol1);
                else
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), sol2);

            }
        }
        this.GetComponent<Tilemap>().RefreshAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
