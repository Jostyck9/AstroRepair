using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
{
    public TileBase Arbre1;
    public TileBase Arbre2;
    public TileBase Arbre3;
    public TileBase Roche1;
    public TileBase Roche2;
    public TileBase Roche3;
    public TileBase Roche4;
    public TileBase BorderTopBot;
    public TileBase BorderLeftright;
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
            int r = Random.Range(0, 9);
            if (r == 0 || r == 6)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Arbre1);
            else if (r == 1 || r == 7)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Arbre2);
            else if (r == 8)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Arbre3);
            else if (r == 2)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche1);
            else if (r == 3)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche2);
            else if (r == 4)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche3);
            else if (r == 5)
                this.GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), Roche4);

        }
        for (int i = -1; i < maxX + 1; i++)
        {
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 3, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 2, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 1, 0), BorderTopBot);
        }
        for (int i = -1; i < maxX + 1; i++)
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, -1, 0), BorderTopBot);
        for (int i = -1; i < maxY + 1; i++)
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 1, i, 0), BorderLeftright);
        for (int i = -1; i < maxY + 1; i++)
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-1, i, 0), BorderLeftright);
        this.GetComponent<Tilemap>().RefreshAllTiles();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
