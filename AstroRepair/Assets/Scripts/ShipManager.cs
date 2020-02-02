using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public SpriteRenderer renderer;
    public List<Sprite> nextSteps;

    public bool isComplete = false;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (index < nextSteps.Count)
            {
                uint nbr = collision.gameObject.GetComponent<ShipPiecePlayer>().currentOnPlayer;
                collision.gameObject.GetComponent<ShipPiecePlayer>().currentOnPlayer = 0;
                Debug.Log(nbr);
                for (uint i = 0; i < nbr; i++)
                {
                    renderer.sprite = nextSteps[index];
                    index++;
                }
            }
            if (index == nextSteps.Count - 1)
            {
                isComplete = true;
            }
            RefreshAir(collision.gameObject);

        }
    }

    private void RefreshAir(GameObject player)
    {
        player.GetComponent<AirManager>().SetAir(player.GetComponent<AirManager>().maxAir);
    }
}
