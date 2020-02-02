using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    public AudioClip[] stepArray;
    public AudioClip[] runArray;
    public AudioSource effectSource;
    public PlayerController playerController;
    private int stepIndex;
    private int runIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PlayRandom()
    {
        stepIndex = Random.Range(0, stepArray.Length);
        runIndex = Random.Range(0, runArray.Length);
        if (!effectSource.isPlaying)
        {
            if (!playerController.isRunning)
                effectSource.PlayOneShot(stepArray[stepIndex]);
            else
                effectSource.PlayOneShot(runArray[runIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

        if (playerController.isMoving)
            PlayRandom();
        else if (effectSource.isPlaying)
            effectSource.Stop();
    }
}
