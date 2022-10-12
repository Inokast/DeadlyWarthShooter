using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

    public AudioSource menuMusic; // Here's where you connect the menu music


    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }
    // Stops all music. Add any new tracks you guys add in here as well.
    public void StopMusic()
    {
        menuMusic.Stop();
    }
}
