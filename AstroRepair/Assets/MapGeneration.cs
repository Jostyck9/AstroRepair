using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
{
    public TileBase Arbre1;
    public TileBase Arbre2;
    public TileBase Roche1;
    public TileBase Roche2;
    public TileBase Roche3;
    public TileBase Roche4;
    public int maxX;
    public int maxY;
    // Start is called before the first frame update
    void Start()
    {
        int max = Random.Range(250, 400);
        for (int i = 0; i < max; i++)
        {
            int x = Random.Range(0, maxX);
            int y = Random.Range(0, maxY);
            int r = Random.Range(0, 7);
            if (r == 0)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Arbre1);
            else if (r == 1)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Arbre2);
            else if (r == 2)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche1);
            else if (r == 3)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche2);
            else if (r == 4)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche3);
            else if (r == 5)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche4);
        }
        
        this.GetComponent<Tilemap>().RefreshAllTiles();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
