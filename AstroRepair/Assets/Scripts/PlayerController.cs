using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float coefSprint;
    public Rigidbody2D rb;

    private bool isRunning = false;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Sprint") > 0)
            isRunning = true;
        else
            isRunning = false;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (isRunning)
            rb.velocity = (movement * (speed * coefSprint) * Time.deltaTime);
        else
            rb.velocity = (movement * speed * Time.deltaTime);
    }
}
