using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_PengenalanHuruf2 : MonoBehaviour {

	[SerializeField]
	private Sprite[] uplatters;

	[SerializeField]
	private Sprite[] lowlatters;

	[SerializeField]
	private AudioClip[] soundLatters;

	[SerializeField]
	private Image[] imageHuruf;

	[SerializeField]
	private AudioSource soundLatter;

	private bool boolLowLatter;
	// Use this for initialization
	void Start () {
		boolLowLatter=false;
		SetLatter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetLatter(){
		if (!boolLowLatter){
			for (int i = 0; i<uplatters.Length; i++){
				imageHuruf[i].sprite = uplatters[i];
				imageHuruf[i].SetNativeSize();
			}
		}else{
			for (int i = 0; i<lowlatters.Length; i++){
				imageHuruf[i].sprite = lowlatters[i];
				imageHuruf[i].SetNativeSize();
			}
		}
	}

	public void ClickLetter(int indexLetter){
		soundLatter.clip = soundLatters[indexLetter];
		soundLatter.Play();
	}

	public void ChangeLatter(){
		if(!boolLowLatter){
			boolLowLatter = true;
		}else
		{
			boolLowLatter=false;
		}
		SetLatter();
	}

}
