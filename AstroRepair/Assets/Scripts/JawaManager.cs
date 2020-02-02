using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawaManager : MonoBehaviour
{
    public GameObject playerToAvoid;
    public GameObject pieceShip;

    public GameObject leftDetector;
    public GameObject rightDetector;
    public GameObject upDetector;
    public GameObject downDetector;
    public Animator animator;
    public GameObject stunAnimation;

    public bool isStun = false;
    private float timeRemainingStun = 0;
    public float amplitude = 1;
    public float amplitudeSpeedOffset = 3.16f;
    private float currentAmplitudeSpeed = 0;
    private Vector2 origin;

    public bool isMoving = false;
    public bool isRunning = false;
    private float speed;
    private float time;
    private Vector2 direction;

    private bool dead = false;

    public enum Face : int
    {
        up,
        down,
        left,
        right
    }

    public Face isFacing;
    private Face lastFacing;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        lastFacing = isFacing;
        ChangeFacing(isFacing);
        ActivDetector(lastFacing);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFacing != isFacing)
        {
            ActivDetector(isFacing);
            lastFacing = isFacing;
        }
        if (isStun)
        {
            updateStun();
        } 
        else if (isMoving)
        {
            if (isRunning)
                RunMovement();
            else
                Movement();
        }
    }

    private void updateStun()
    {
        if (timeRemainingStun > 0)
        {
            timeRemainingStun -= Time.deltaTime;
        } else
        {
            isStun = false;
            stunAnimation.SetActive(false);
        }
    }

    private void Movement()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            rb.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            isMoving = false;
            animator.SetBool("isMoving", false);
        }
    }

    private void RunMovement()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            float offset = Mathf.Sin(currentAmplitudeSpeed);
            Vector2 movement = direction;
            /*if (offset > 0)
                offset = 1;
            else
                offset = -1;*/
            if (direction.x != 0)
            {
                movement.y = offset;
                /*transform.position = new Vector3(transform.position.x, origin.y + (offset * amplitude), transform.position.z);*/
            }
            else
            {
                movement.x = offset;
                /*transform.position = new Vector3(origin.x + (offset * amplitude), transform.position.y, transform.position.z);*/
            }
            currentAmplitudeSpeed += (amplitudeSpeedOffset * Time.deltaTime);
            rb.velocity = movement * speed * Time.deltaTime;
        }
        else
        {
            /*currentAmplitudeSpeed = 0;*/
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
            isMoving = false;
            isRunning = false;
        }
    }

    private void UpdateFacingFromDirection()
    {
        if (direction.x > 0 && direction.y > 0)
        {
            if (direction.x > direction.y)
                ChangeFacing(Face.right);
            else
                ChangeFacing(Face.up);
        } 
        else if (direction.x > 0 && direction.y < 0)
        {
            if (direction.x > direction.y * -1)
                ChangeFacing(Face.right);
            else
                ChangeFacing(Face.down);
        }
        if (direction.x < 0 && direction.y > 0)
        {
            if (direction.x * -1 > direction.y)
                ChangeFacing(Face.left);
            else
                ChangeFacing(Face.up);
        }
        else if (direction.x < 0 && direction.y < 0)
        {
            if (direction.x * -1 > direction.y * -1)
                ChangeFacing(Face.left);
            else
                ChangeFacing(Face.down);
        } 
        else if (direction.x == 0 && direction.y != 0)
        {
            if (direction.y > 0)
                ChangeFacing(Face.up);
            else
                ChangeFacing(Face.down);
        }
        else if (direction.x != 0 && direction.y == 0)
        {
            if (direction.x > 0)
                ChangeFacing(Face.right);
            else
                ChangeFacing(Face.left);
        }
    }

    private void ActivDetector(Face side)
    {
        switch (side)
        {
            case Face.down:
                leftDetector.SetActive(false);
                rightDetector.SetActive(false);
                upDetector.SetActive(false);
                downDetector.SetActive(true);
                break;
            case Face.up:
                leftDetector.SetActive(false);
                rightDetector.SetActive(false);
                upDetector.SetActive(true);
                downDetector.SetActive(false);
                break;
            case Face.left:
                leftDetector.SetActive(true);
                rightDetector.SetActive(false);
                upDetector.SetActive(false);
                downDetector.SetActive(false);
                break;
            case Face.right:
                leftDetector.SetActive(false);
                rightDetector.SetActive(true);
                upDetector.SetActive(false);
                downDetector.SetActive(false);
                break;
            default:
                leftDetector.SetActive(false);
                rightDetector.SetActive(false);
                upDetector.SetActive(false);
                downDetector.SetActive(false);
                break;
        }
    }

    public void ChangeFacing(Face direction)
    {
        isFacing = direction;
        animator.SetInteger("DirectionState", (int)direction);
    }

    public void Move(Vector2 direction, float speed, float time)
    {
        if (isStun)
            return;
        isMoving = true;
        animator.SetBool("isMoving", true);
        this.speed = speed;
        this.time = time;
        this.direction = direction;
        origin = new Vector2(transform.position.x, transform.position.y);
        Debug.Log(speed);
        UpdateFacingFromDirection();
    }

    public void Run(Vector2 direction, float speed, float time)
    {
        if (isStun)
            return;
        isRunning = true;
        animator.SetBool("isRunning", true);
        Move(direction, speed, time);
    }

    public void Stun(float seconds)
    {
        stunAnimation.SetActive(true);
        timeRemainingStun = seconds;
        isStun = true;
        animator.SetBool("isRunning", false);
        animator.SetBool("isMoving", false);
        rb.velocity = new Vector2(0, 0);
    }

    public void Die()
    {
        if (dead)
            return;
        dead = true;
        SpawnPiece();
        Destroy(gameObject);
    }

    public void SpawnPiece()
    {
        float offset = 0;
        Vector2 positionSpawn = transform.position;
        bool right = false;

        switch (isFacing)
        {
            case Face.down:
                positionSpawn.x -= offset;
                break;
            case Face.up:
                positionSpawn.x += offset;
                right = true;
                break;
            case Face.right:
                positionSpawn.x -= offset;
                break;
            case Face.left:
                positionSpawn.x += offset;
                right = true;
                break;
            default:
                break;
        }
        GameObject piece = Instantiate(pieceShip, new Vector3(positionSpawn.x, positionSpawn.y, transform.position.z), transform.rotation);
        piece.GetComponent<PieceAnimation>().Jump(right);
    }
}
