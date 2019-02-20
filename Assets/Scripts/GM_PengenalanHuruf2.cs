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
		if (!boolLowLatter){
			for (int i = 0; i<uplatters.Length; i++){
				imageHuruf[i].transform.GetChild(0).GetComponent<Image>().sprite = uplatters[i];
			}
		}else{
			for (int i = 0; i<lowlatters.Length; i++){
				imageHuruf[i].transform.GetChild(i).GetComponent<Image>().sprite = lowlatters[i];
			}
		}
	}

	public void ClickLetter(int indexLetter){
		autoButton=false;
		if (autoCoroutine!=null){
			StopCoroutine(autoCoroutine);
		}
		PlaySound(indexLetter);
	}

	private void PlaySound(int indexLetter){
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

	public void AutoButtonActive(){
		if(!autoButton){
			autoButton = true;
			autoCoroutine = StartCoroutine(AutoPlay());
			Debug.Log("true");
		}else{
			autoButton=false;
			StopCoroutine(autoCoroutine);
		}
	}

	private IEnumerator AutoPlay()
	{
		for (int i = 0; i<uplatters.Length;i++){
			Debug.Log(i);
			imageHuruf[i].GetComponent<Animator>().SetTrigger("Start");
			PlaySound(i);
			yield return new WaitForSeconds(2);
			imageHuruf[i].GetComponent<Animator>().SetTrigger("Start");
		}
		autoButton=false;
	}
}
