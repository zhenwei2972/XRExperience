using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource fireBallShootSound;
    public AudioSource explodingSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFireBallShootSound()
    {
        if (!fireBallShootSound.isPlaying)
        {
            fireBallShootSound.Play();
        }
    }

    public void PlayExplodingSound()
    {
        if (!explodingSound.isPlaying)
        {
            explodingSound.Play();
        }
    }
}
