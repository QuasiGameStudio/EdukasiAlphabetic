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

	private IEnumerator AutoPlay()
	{
		for (int i = 0; i < uplatters.Length; i++)
		{
			indexLatter++;
			SetLatter();
			yield return new WaitForSeconds(2);
		}
		
	}

	private void SetLatter(){
		imageHurufBesar.sprite = uplatters[indexLatter];
		imageHurufKecil.sprite = lowlatters[indexLatter];
		soundLatter.clip = soundLatters[indexLatter];
		soundLatter.Play();
	}

	public void Next(){
		autoButton=false;
		indexLatter++;
		if (indexLatter > 25){
			indexLatter = 0;
		}
		SetLatter();
	}

	public void Prev(){
		autoButton=false;
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
			Debug.Log("true");
		}else{
			autoButton=false;
			StopCoroutine(autoCoroutine);
			Debug.Log("false");
		}
		soundLatter.Play();
	}
}
