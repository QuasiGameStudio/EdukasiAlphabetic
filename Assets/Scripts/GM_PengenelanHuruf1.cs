using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_PengenelanHuruf1 : MonoBehaviour {

	[SerializeField]
	private Sprite[] uplatters;

	[SerializeField]
	private Sprite[] lowlatters;

	[SerializeField]
	private AudioClip[] soundLatters;

	[SerializeField]
	private Image imageHurufBesar;

	[SerializeField]
	private Image imageHurufKecil;

	[SerializeField]
	private AudioSource soundLatter;

	private int indexLatter;

	private bool autoButton;

	private Coroutine autoCoroutine;
	// Use this for initialization
	void Start () {
		indexLatter=0;
		SetLatter();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}

	public void PlaySound(){
		if (autoCoroutine!=null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
		SetLatter();
	}

	private void SetLatter(){
		imageHurufBesar.sprite = uplatters[indexLatter];
		imageHurufKecil.sprite = lowlatters[indexLatter];
		soundLatter.clip = soundLatters[indexLatter];
		AudioManager.Instance.PlaySFXClip(soundLatter.clip);
	}

	public void Next(){
		autoButton=false;
		if (autoCoroutine!=null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
		indexLatter++;
		if (indexLatter > 25){
			indexLatter = 0;
		}
		SetLatter();
	}

	public void Prev(){
		autoButton=false;
		if (autoCoroutine!=null){
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
		indexLatter--;
		if(indexLatter < 0){
			indexLatter = 25;
		}
		SetLatter();
	}

	public void AutoButtonActive(){
		if (!autoButton){
			autoButton=true;
			autoCoroutine = StartCoroutine(AutoPlay());
			AudioManager.Instance.PlaySFXClip(soundLatter.clip);
		}else{
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
		}
	}

	private IEnumerator AutoPlay()
	{
		if (indexLatter == 25){
			indexLatter=0;
		}
		for (int i = indexLatter; i < uplatters.Length; i++)
		{
			SetLatter();
			yield return new WaitForSeconds(2);
			indexLatter++;
		}
		indexLatter=0;	
		autoButton=false;	
	}
}
