using UnityEngine;
using System.Collections;

public class RandomSoundOnStart : MonoBehaviour 
{
    public bool randomizePitch = true;
    public AudioClip[] clips;

    void Start()
    {
        audio.clip = clips[Random.Range(0, clips.Length)];
        if(randomizePitch)
            audio.pitch = Random.Range(0.8f, 1.2f);

        audio.Play();
    }
}
