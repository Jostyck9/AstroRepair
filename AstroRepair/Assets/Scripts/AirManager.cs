using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirManager : MonoBehaviour
{
    public float maxAir;
    public float currentAir;
    public float airPerSeconds;
    public float airPerSecondsRun;
    public float airShoot;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        currentAir = maxAir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (playerController.isDead)
            return;
        if (playerController.isRunning)
            currentAir -= airPerSecondsRun * Time.deltaTime;
        else
            currentAir -= airPerSeconds * Time.deltaTime;
        if (playerController.hasShoot)
        {
            currentAir -= airShoot;
            playerController.hasShoot = false;
        }
        if (currentAir < 0)
            currentAir = 0;
        CheckDead();
        Debug.Log(currentAir);
    }

    private void CheckDead()
    {
        if (currentAir <= 0)
            playerController.Die();
    }
}
