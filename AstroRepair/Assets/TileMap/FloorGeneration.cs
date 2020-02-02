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
    public TileBase Wood1;
    public TileBase Wood2;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -1; i < maxX + 1; i++)
        {
            for (int j = -1; j < maxY + 3; j++)
            {
                int s = Random.Range(0, 20);
                if (s == 1 || s == 2)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), bush1);
                else if (s == 3 || s == 4)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), bush2);
                else if (s == 5)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), Wood1);
                else if (s == 6)
                    this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), Wood2);
                else if (s > 6 && s <= 13)
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
