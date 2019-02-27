using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : Singleton<BGM>
{
    // Start is called before the first frame update

    AudioSource BGMSource;
    private static BGM BGMInstance;

    [SerializeField]
    AudioClip[] BGMClips;

    void Awake(){

        if (BGMInstance == null){
            BGMInstance = this;
            GameData.Instance.GetTempBGMVolume();
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        BGMSource = GetComponent<AudioSource>();
        SetBGMClip(0);
    }

    void Start()
    {
        SetBGMVolume();
    }

    // Update is called once per frame
    void Update()
    {
        SetBGMVolume();   
    }

    private void PlayBGMClip(){
        BGMSource.Play();
    }

    private void StopBGMClip(){
        BGMSource.Stop();
    }

    private void SetBGMVolume(){
        BGMSource.volume = GameData.Instance.GetBGMVolume();
    }

    public void DecreaseBGMVolume(){
        GameData.Instance.SetTempBGMVolume();
        GameData.Instance.SetBGMVolume(GameData.Instance.GetBGMVolume()/4);
    }

    public void IncreaseBGMVolume(){
        GameData.Instance.GetTempBGMVolume(); 
    }

    public void SetBGMClip(int index){
        StopBGMClip();
        BGMSource.clip = BGMClips[index];
        PlayBGMClip();
    }
}
