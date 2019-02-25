﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource BGMSource;
    private static BGM BGMInstance;

    void Awake(){

        if (BGMInstance == null){
            BGMInstance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        BGMSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SetBGMVolume();
        PlayBGMClip();
    }

    // Update is called once per frame
    void Update()
    {
        SetBGMVolume();   
    }

    private void PlayBGMClip(){
        BGMSource.PlayOneShot(BGMSource.clip);
    }

    private void SetBGMVolume(){
        BGMSource.volume = GameData.Instance.GetBGMVolume();
    }
}
