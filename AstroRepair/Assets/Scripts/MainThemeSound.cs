using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainThemeSound : MonoBehaviour
{
    public AudioClip[] mainTheme;
    public AudioSource[] effectSource;
    public AirManager airManager;
    public AudioMixerSnapshot[] audioMixerSnapshot;
    private int curentSnapshot;
    // Start is called before the first frame update
    void Start()
    {
        playSong();
    }

    void playSong()
    {
        if (!effectSource[0].isPlaying)
            effectSource[0].PlayOneShot(mainTheme[0]);
        if (!effectSource[1].isPlaying)
            effectSource[1].PlayOneShot(mainTheme[1]);
        if (!effectSource[2].isPlaying)
            effectSource[2].PlayOneShot(mainTheme[2]);
        if (airManager.currentAir <= 30 && curentSnapshot != 2)
        {
            audioMixerSnapshot[2].TransitionTo(0);
            curentSnapshot = 2;
        }
        else if (airManager.currentAir > 30 && airManager.currentAir <= 60 && curentSnapshot != 1)
        {
            audioMixerSnapshot[1].TransitionTo(0);
            curentSnapshot = 1;
        }
        else if (airManager.currentAir > 60 && curentSnapshot != 0)
        {
            audioMixerSnapshot[0].TransitionTo(0);
            curentSnapshot = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playSong();        
    }
}
