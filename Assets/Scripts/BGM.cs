using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : Singleton<BGM>
{
    // Start is called before the first frame update

    AudioSource BGMSource;
    private static BGM BGMInstance;

    void Awake(){

        if (BGMInstance == null){
            BGMInstance = this;
            GameData.Instance.GetTempBGMVolume();
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
        Debug.Log(BGMSource.volume);
    }

    private void PlayBGMClip(){
        BGMSource.PlayOneShot(BGMSource.clip);
    }

    private void SetBGMVolume(){
        BGMSource.volume = GameData.Instance.GetBGMVolume();
    }

    public void DecreaseBGMVolume(){
        GameData.Instance.SetTempBGMVolume();
        GameData.Instance.SetBGMVolume(GameData.Instance.GetBGMVolume()/10);
    }

    public void IncreaseBGMVolume(){
        GameData.Instance.GetTempBGMVolume(); 
    }
}
