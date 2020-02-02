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
        /*left_up,
        left_down,
        right_up,
        right_down*/
    }

    public GameObject leftSpawner;
    public GameObject rightSpawner;
    public GameObject upSpawner;
    public GameObject downSpawner;
    public GameObject left_upSpawner;
    public GameObject left_downSpawner;
    public GameObject right_upSpawner;
    public GameObject right_downSpawner;

    public Animator animator;

    private facing facingDirection;
    private facing lastFacingDirection;

    public bool onPause = false;
    private float timePause = 0;

    public float speed;
    public float coefSprint;
    public Rigidbody2D rb;

    public bool isDead = false;
    public bool hasShoot = false;
    public bool isRunning = false;
    public bool isMoving = false;

    private List<GameObject> spawnersList = new List<GameObject>();

    public float intervalShoot = 2.0f;
    private float timeRemainingShoot = 0;
    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        lastFacingDirection = facingDirection;
        animator.SetInteger("DirectionState", (int)facingDirection);
        spawnersList.Add(leftSpawner);
        spawnersList.Add(rightSpawner);
        spawnersList.Add(upSpawner);
        spawnersList.Add(downSpawner);
        /*spawnersList.Add(left_upSpawner);
        spawnersList.Add(left_downSpawner);
        spawnersList.Add(right_upSpawner);
        spawnersList.Add(right_downSpawner);*/
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

        if (!onPause && Input.GetAxis("Sprint") > 0)
            isRunning = true;
        else
            isRunning = false;
        animator.SetBool("isRunning", isRunning);

        if (!onPause)
        {
            UpdateFacing(moveHorizontal, moveVertical);
            UpdateWeapons();
            CheckShoot();
            Move(moveHorizontal, moveVertical);
        } else
        {
            timePause -= Time.deltaTime;
            if (timePause < 0)
                onPause = false;
        }
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        if (isDead)
            return;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
            isMoving = false;
        else
            isMoving = true;
        animator.SetBool("isMoving", isMoving);
        if (isRunning)
            rb.velocity = (movement * (speed * coefSprint) * Time.deltaTime);
        else
            rb.velocity = (movement * speed * Time.deltaTime);
    }

    private void CheckShoot()
    {
        if (isDead)
            return;
        timeRemainingShoot -= Time.deltaTime;
        if (timeRemainingShoot <= 0 && Input.GetAxis("Fire1") > 0)
        {
            Shoot();
            timeRemainingShoot = intervalShoot;
        }
    }

    private void Shoot()
    {
        if (isDead)
            return;
        currentWeapon.GetComponent<Shooter>().shoot();
        hasShoot = true;
    }
    

    private void UpdateFacing(float moveHorizontal, float moveVertical)
    {
        if (isDead)
            return;

        if (moveHorizontal > 0 && moveVertical >= 0)
        {
            if (moveHorizontal > moveVertical)
                facingDirection = facing.right;
            else
                facingDirection = facing.up;
        } else if (moveHorizontal > 0 && moveHorizontal < 0)
        {
            if (moveHorizontal > moveVertical * -1)
                facingDirection = facing.right;
            else
                facingDirection = facing.down;
        } else if (moveHorizontal < 0 && moveVertical >= 0)
        {
            if (moveHorizontal * -1 > moveVertical)
                facingDirection = facing.left;
            else
                facingDirection = facing.up;
        } else if (moveHorizontal < 0 && moveHorizontal < 0)
        {
            if (moveHorizontal < moveVertical)
                facingDirection = facing.left;
            else
                facingDirection = facing.down;
        } 
        else if (moveHorizontal >= 0 && moveVertical > 0)
        {
            if (moveHorizontal < moveVertical)
                facingDirection = facing.up;
            else
                facingDirection = facing.right;
        }
        else if (moveHorizontal < 0 && moveHorizontal > 0)
        {
            if (moveHorizontal * -1 > moveVertical)
                facingDirection = facing.left;
            else
                facingDirection = facing.up;
        }
        else if (moveHorizontal >= 0 && moveVertical < 0)
        {
            if (moveHorizontal > moveVertical * -1)
                facingDirection = facing.right;
            else
                facingDirection = facing.down;
        }


/*        if (moveHorizontal > 0 && moveVertical == 0)
            facingDirection = facing.right;
        else if (moveHorizontal < 0 && moveVertical == 0)
            facingDirection = facing.left;
        else if (moveHorizontal == 0 && moveVertical > 0)
            facingDirection = facing.up;
        else if (moveHorizontal == 0 && moveVertical < 0)
            facingDirection = facing.down;
*/        /*else if (moveHorizontal < 0 && moveVertical < 0)
            facingDirection = facing.left_down;
        else if (moveHorizontal > 0 && moveVertical < 0)
            facingDirection = facing.right_down;
        else if (moveHorizontal < 0 && moveVertical > 0)
            facingDirection = facing.left_up;
        else if (moveHorizontal > 0 && moveVertical > 0)
            facingDirection = facing.right_up;*/
        animator.SetInteger("DirectionState", (int)facingDirection);
    }

    private void UpdateWeapons()
    {
        if (isDead)
            return;
        if (lastFacingDirection != facingDirection)
        {
            currentWeapon = spawnersList[(int)facingDirection];
            lastFacingDirection = facingDirection;
        }
    }

    public void Die()
    {
        isDead = true;
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void Pause(float time)
    {
        onPause = true;
        rb.velocity = new Vector2(0, 0);
        timePause = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShipPiece")
        {

            if (collision.gameObject.GetComponent<PieceAnimation>().used == true)
                return;
            collision.gameObject.GetComponent<PieceAnimation>().used = true;
            Destroy(collision.gameObject);
            gameObject.GetComponent<ShipPiecePlayer>().currentOnPlayer += 1;
            gameObject.GetComponent<ShipPiecePlayer>().nbrPieces += 1;
        }
    }
}
