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

	private bool autoButton;

	private Coroutine autoCoroutine;
	private Coroutine playSoundCoroutine;
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
		if (autoCoroutine != null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
		SetLatter();
	}

	public void Prev(){
		indexLatter--;
		if(indexLatter < 0){
			indexLatter = 25;
		}
		if (autoCoroutine != null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
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
		if(autoCoroutine != null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
		if (playSoundCoroutine != null){
			StopCoroutine(playSoundCoroutine);
			playSoundCoroutine =null;
		}
		playSoundCoroutine = StartCoroutine(_PLayClip());
	}

	private IEnumerator _PLayClip()
	{
		AudioManager.Instance.PlaySFXClip(soundLatters[indexLatter]);
		yield return new WaitForSeconds(1);
		AudioManager.Instance.PlaySFXClip(soundExtra);
		yield return new WaitForSeconds(1);
		AudioManager.Instance.PlaySFXClip(soundObjects[indexLatter]);
	}
	

	public void AutoButtonActive(){
		if (!autoButton){
			autoButton=true;
			autoCoroutine = StartCoroutine(AutoPlay());
			// soundLatter.Play();
		}else{
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
	}

	private IEnumerator AutoPlay()
	{
		for (int i = indexLatter; i < uplatters.Length; i++)
		{
			SetLatter();
			yield return new WaitForSeconds(3);
			indexLatter++;
		}
		
	}
}
