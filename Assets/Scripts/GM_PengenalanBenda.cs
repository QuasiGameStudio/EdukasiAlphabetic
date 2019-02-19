using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_PengenalanBenda : MonoBehaviour {

	[SerializeField]
	private Sprite[] uplatters;

	[SerializeField]
	private Sprite[] lowlatters;

	[SerializeField]
	private Sprite[] wordImages;

	[SerializeField]
	private AudioClip[] soundLatters;

	[SerializeField]
	private AudioClip[] soundObjects;

	[SerializeField]
	private AudioClip soundExtra;

	[SerializeField]
	private Image imageHurufBesar;

	[SerializeField]
	private Image imageHurufKecil;

	[SerializeField]
	private Image wordImage;

	[SerializeField]
	private AudioSource soundOutput;

	private int indexLatter;
	// Use this for initialization
	void Start () {
		indexLatter =0;
		SetLatter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetLatter(){
		imageHurufBesar.sprite = uplatters[indexLatter];
		imageHurufKecil.sprite = lowlatters[indexLatter];
		wordImage.sprite = wordImages[indexLatter];
		PlayClip();
	}

	public void Next(){
		indexLatter++;
		if (indexLatter > 25){
			indexLatter = 0;
		}
		SetLatter();
	}

	public void Prev(){
		indexLatter--;
		if(indexLatter < 0){
			indexLatter = 25;
		}
		SetLatter();
	}

	public void SetClip(AudioClip clip){
		// soundOutputs[0].clip=soundLatters[indexLatter];
		// soundOutputs[2].clip=soundObjects[indexLatter];
		// soundOutputs[1].clip=soundExtra;

		// soundOutputs.clip = 
	}

	public void PlayClip(){
		// StartCoroutine("_PlayClip");
		StartCoroutine(_PLayClip());
	}

	private IEnumerator _PLayClip()
	{
		soundOutput.clip = soundLatters[indexLatter];
		soundOutput.Play();
		yield return new WaitForSeconds(1);
		soundOutput.clip = soundExtra;
		soundOutput.Play();
		yield return new WaitForSeconds(1);
		soundOutput.clip = soundObjects[indexLatter];
		soundOutput.Play();
	}
	
}
