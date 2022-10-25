using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioM;

    [SerializeField]
    public AudioClip Nevermind;

    public void playSong(string x) {
        AudioM.Stop();
        if (x == "Nevermind") {
            AudioM.clip = Nevermind;
            AudioM.time = 0;
            AudioM.Play();
        }
    }
}
