using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Home : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider SFXSlider;
    
    [SerializeField]
    private Slider BGMSlider;
    
    void Start()
    {
        SFXSlider.value = GameData.Instance.GetSFXVolume();
        BGMSlider.value = GameData.Instance.GetBGMVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
