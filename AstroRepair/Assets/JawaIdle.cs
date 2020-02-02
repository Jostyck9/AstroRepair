using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawaIdle : MonoBehaviour
{
    public AudioClip[] idle;
    public AudioClip[] step;
    public AudioSource[] effectSource;
    public JawaManager jawaManager;

    private int n;
    private int stepIndex;
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
        n = Random.Range(0, idle.Length);
        stepIndex = Random.Range(0, step.Length);
        if (!effectSource[0].isPlaying)
            effectSource[0].PlayOneShot(idle[n]);
        if (jawaManager.isMoving)
        {
            if (!effectSource[1].isPlaying)
                effectSource[1].PlayOneShot(step[stepIndex]);
        }
        else if (effectSource[1].isPlaying)
            effectSource[1].Stop();
    }
}
