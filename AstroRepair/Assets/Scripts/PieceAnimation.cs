using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAnimation : MonoBehaviour
{
    public BoxCollider2D collider;
    public float duration = 3;
    public bool used = false;
    public float speed = 5;

    private bool side = false; //left = false, right = true;
    private bool animationStarted = false;

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
        if (animationStarted)
            updateAnim();
    }

    private void updateAnim()
    {
        float mult = 1;

        if (!side)
            mult = -1;
        if (duration > 0)
        {
            duration -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * mult), transform.position.y, transform.position.z);
        } else
        {
            collider.enabled = true;
        }
    }

    public void Jump(bool right)
    {
        side = right;
        animationStarted = true;
        collider.enabled = false;
    }

}
