using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGeneration : MonoBehaviour
{
    public TileBase tileBase;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), tileBase);
            }
        }
        this.GetComponent<Tilemap>().RefreshAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
