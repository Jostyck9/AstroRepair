using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum facing : int
    {
        left,
        right,
        up,
        down,
        left_up,
        left_down,
        right_up,
        right_down
    }

    public GameObject leftSpawner;
    public GameObject rightSpawner;
    public GameObject upSpawner;
    public GameObject downSpawner;
    public GameObject left_upSpawner;
    public GameObject left_downSpawner;
    public GameObject right_upSpawner;
    public GameObject right_downSpawner;

    public facing facingDirection;
    private facing lastFacingDirection;

    public float speed;
    public float coefSprint;
    public Rigidbody2D rb;

    private bool isRunning = false;
    private List<GameObject> spawnersList = new List<GameObject>();

    public float intervalShoot = 2.0f;
    private float timeRemainingShoot = 0;
    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        lastFacingDirection = facingDirection;
        spawnersList.Add(leftSpawner);
        spawnersList.Add(rightSpawner);
        spawnersList.Add(upSpawner);
        spawnersList.Add(downSpawner);
        spawnersList.Add(left_upSpawner);
        spawnersList.Add(left_downSpawner);
        spawnersList.Add(right_upSpawner);
        spawnersList.Add(right_downSpawner);
        currentWeapon = leftSpawner;
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

        updateFacing(moveHorizontal, moveVertical);
        updateWeapons();
        checkShoot();

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (isRunning)
            rb.velocity = (movement * (speed * coefSprint) * Time.deltaTime);
        else
            rb.velocity = (movement * speed * Time.deltaTime);
    }

    private void checkShoot()
    {
        timeRemainingShoot -= Time.deltaTime;
        if (timeRemainingShoot <= 0 && Input.GetAxis("Fire1") > 0)
        {
            shoot();
            timeRemainingShoot = intervalShoot;
        }
    }

    private void shoot()
    {
        currentWeapon.GetComponent<Shooter>().shoot();
    }
    

    private void updateFacing(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal > 0 && moveVertical == 0)
            facingDirection = facing.right;
        else if (moveHorizontal < 0 && moveVertical == 0)
            facingDirection = facing.left;
        else if (moveHorizontal == 0 && moveVertical > 0)
            facingDirection = facing.up;
        else if (moveHorizontal == 0 && moveVertical < 0)
            facingDirection = facing.down;
        else if (moveHorizontal < 0 && moveVertical < 0)
            facingDirection = facing.left_down;
        else if (moveHorizontal > 0 && moveVertical < 0)
            facingDirection = facing.right_down;
        else if (moveHorizontal < 0 && moveVertical > 0)
            facingDirection = facing.left_up;
        else if (moveHorizontal > 0 && moveVertical > 0)
            facingDirection = facing.right_up;
    }

    private void updateWeapons()
    {
        if (lastFacingDirection != facingDirection)
        {
            currentWeapon = spawnersList[(int)facingDirection];
            lastFacingDirection = facingDirection;
        }
    }
}
