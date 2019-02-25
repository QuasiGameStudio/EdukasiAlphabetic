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
	private GameObject[] imageHuruf;

	[SerializeField]
	private AudioSource soundLatter;

	private bool boolLowLatter;

	private bool autoButton;

	private int indexLatter;

	private Coroutine autoCoroutine;
	// Use this for initialization
	void Start () {
		boolLowLatter=false;
		SetLatter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetLatter(){
		for (int i = 0; i<uplatters.Length; i++){
			if (!boolLowLatter){
				imageHuruf[i].transform.GetChild(0).GetComponent<Image>().sprite = uplatters[i];
			}else{
				imageHuruf[i].transform.GetChild(0).GetComponent<Image>().sprite = lowlatters[i];
			}
			// imageHuruf[i].transform.GetChild(0).GetComponent<Image>().SetNativeSize();
		}
	}

	public void ClickLetter(int indexLetter){
		autoButton=false;
		if (autoCoroutine!=null){
			StopCoroutine(autoCoroutine);
			imageHuruf[indexLatter].GetComponent<Animator>().Play("AlphabetRotate");			
			imageHuruf[indexLatter].GetComponent<Animator>().SetTrigger("Start");
			autoCoroutine=null;
		}
		
		PlaySound(indexLetter);
	}

	private void PlaySound(int indexLetter){
		soundLatter.clip = soundLatters[indexLetter];
		AudioManager.Instance.PlaySFXClip(soundLatter.clip);
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

	public void AutoButtonActive(){
		if(!autoButton){
			autoButton = true;
			autoCoroutine = StartCoroutine(AutoPlay());
		}else{
			autoButton=false;
			StopCoroutine(autoCoroutine);
			autoCoroutine=null;
			imageHuruf[indexLatter].GetComponent<Animator>().SetTrigger("Start");
		}
	}

	private IEnumerator AutoPlay()
	{
		for (indexLatter = 0; indexLatter<uplatters.Length;indexLatter++){
			imageHuruf[indexLatter].GetComponent<Animator>().SetTrigger("Start");
			PlaySound(indexLatter);
			yield return new WaitForSeconds(2);
			imageHuruf[indexLatter].GetComponent<Animator>().SetTrigger("Start");
		}
		indexLatter=0;
		autoButton=false;
	}
}
