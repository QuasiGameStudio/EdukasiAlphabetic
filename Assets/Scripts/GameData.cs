using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    // Start is called before the first frame update
    
    void Awake()
    {
        GetSFXVolume();
        GetBGMVolume();
    }
    
    void Start()
    {
        
    }

    public void SetSFXVolume(float volume){
        PlayerPrefs.SetFloat("SFXVolume", volume);   
    }

    public float GetSFXVolume(){
        return PlayerPrefs.GetFloat("SFXVolume",1);
    }

    public void SetBGMVolume(float volume){
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public float GetBGMVolume(){
        return PlayerPrefs.GetFloat("BGMVolume", 1);
    }
}
