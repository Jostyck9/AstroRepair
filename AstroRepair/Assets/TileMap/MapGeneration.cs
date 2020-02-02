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
        for (int i = -10; i < maxY + 10; i++)
        {
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 1, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 2, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 3, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 4, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 5, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 6, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 7, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 8, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 9, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 10, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 11, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(maxX + 12, i, 0), BorderLeftright);
        }
        for (int i = -10; i < maxY + 10; i++)
        {
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-12, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-11, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-10, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-9, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-8, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-7, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-6, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-5, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-4, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-3, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-2, i, 0), BorderLeftright);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(-1, i, 0), BorderLeftright);
        }
        for (int i = -10; i < maxX + 10; i += 3)
        {
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 6, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 3, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, maxY + 1, 0), BorderTopBot);
        }
        for (int i = -10; i < maxX + 10; i++)
        {
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, -2, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, -4, 0), BorderTopBot);
            this.GetComponent<Tilemap>().SetTile(new Vector3Int(i, -7, 0), BorderTopBot);
        }
        this.GetComponent<Tilemap>().RefreshAllTiles();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
