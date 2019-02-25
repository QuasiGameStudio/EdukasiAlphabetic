using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    // Start is called before the first frame update
    AudioSource audioSource;

    void Start()
    {
        audioSource.volume = GameData.Instance.GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFXClip(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
