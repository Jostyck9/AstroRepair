using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
{
    public TileBase tileBase;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        int max = Random.Range(0, 50);
        for (int i = 0; i < max; i++)
        {
            int x = Random.Range(0, maxX);
            int y = Random.Range(0, maxY);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), tileBase);
        }
        this.GetComponent<Tilemap>().RefreshAllTiles();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
