using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSFXVolume(float volume){
        PlayerPrefs.SetFloat("SFXVolume", volume);   
        Debug.Log(GetSFXVolume());
    }

    public float GetSFXVolume(){
        return PlayerPrefs.GetFloat("SFXVolume",1);
    }
}
