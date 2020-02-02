using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIJawa : MonoBehaviour
{

    public JawaManager jm;
    public float speed;
    public float speedRun;
    public float timeRun;
    public float maxTimeWalk;
    public int frequenceWalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!jm.isMoving && Random.Range(0, frequenceWalk) == 0)
        {
            float timeNextMove = Random.Range(0.0f, maxTimeWalk);
            Vector2 nextDirection = new Vector2(0, 0);

            switch (Random.Range(0, 4))
            {
                case 0:
                    nextDirection.x = 1;
                    break;
                case 1:
                    nextDirection.x = -1;
                    break;
                case 2:
                    nextDirection.y = 1;
                    break;
                case 3:
                    nextDirection.y = -1;
                    break;
                default:
                    break;
            }
            jm.Move(nextDirection, speed, timeNextMove);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = new Vector2();

            if (jm.isFacing == JawaManager.Face.down)
            {
                direction.y = 1;
            }
            else if (jm.isFacing == JawaManager.Face.up)
            {
                direction.y = -1;
            }
            else if (jm.isFacing == JawaManager.Face.left)
            {
                direction.x = 1;
            } 
            else
            {
                direction.x = -1;
            }
            jm.Run(direction, speedRun, timeRun);
        }
    }
}
