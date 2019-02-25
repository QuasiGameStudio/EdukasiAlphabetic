using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_TebakHuruf : MonoBehaviour {

	[SerializeField]
	private Sprite[] latters;

	[SerializeField]
	private AudioClip[] soundLatters;

	[SerializeField]
	private AudioSource questionAudio;

	private int mainNumber;

	[SerializeField]
	private Image[] options;

	private int answer;
	private int userAnswer;

	private int playTime;

	private int[] randomLatters;
	private int[] randomQuestionLetters;

	private int indexRandomLetters;
	private int indexRandomQuestionLetters;

	[SerializeField]
	private GameObject popUpAnswer;

	[SerializeField]
	private GameObject popUpReward;

	// Use this for initialization
	void Start () {
		playTime =0;
		setRandomArray();
		reshuffle();
		reset ();		
	}
	
	// Update is called once per frame
	void Update () {
		if (!popUpAnswer.activeSelf && !popUpReward.activeSelf){
			CheckAnswer ();
		}
	}

	private void SetQuestion () {
		mainNumber = randomLatters[indexRandomLetters];
		indexRandomLetters++;
		questionAudio.clip = soundLatters[mainNumber];
	}

	private void SetOption () {
		answer = Random.Range (0, 3);
		options[answer].sprite = latters[mainNumber];
		for (int i = 0; i < 3; i++) {
			int x = randomQuestionLetters[indexRandomQuestionLetters];
			indexRandomQuestionLetters++;
			if (i != answer) {
				if (x == mainNumber){
					x= randomQuestionLetters[indexRandomQuestionLetters];
					indexRandomQuestionLetters++;
				}
				options[i].sprite = latters[x];
			}
			options[i].SetNativeSize ();
		}
	}

	public void GiveAnswer (int userAnswer) {
		this.userAnswer = userAnswer;
	}

	private void CheckAnswer () {
		if (userAnswer == answer) {
			playTime= playTime+1;
			Debug.Log(playTime);
			Debug.Log ("nice");
			StartCoroutine(showPopUp());
		}
	}

	private IEnumerator showPopUp(){
		if (playTime == 10){
			popUpReward.SetActive(true);
		}else{
			popUpAnswer.SetActive(true);
			yield return new WaitForSeconds(1);
			popUpAnswer.SetActive(false);
			reset();
		}
	}

	private void setRandomArray(){
		randomLatters = new int[latters.Length];
		randomQuestionLetters = new int[latters.Length];
		for (int i=0; i<latters.Length; i++){
			randomLatters[i]=i;
			randomQuestionLetters[i]=i;
		}
	}

	private void reshuffle(){
		for (int t = 0; t< randomLatters.Length; t++){
			int tmp = randomLatters[t];
			int r = Random.Range(t, randomLatters.Length);
			randomLatters[t]=randomLatters[r];
			randomLatters[r]=tmp;
		}
	}

	private void reshuffleRandomQuestionLetters(){
		for (int t = 0; t< randomQuestionLetters.Length; t++){
			int tmp = randomQuestionLetters[t];
			int r = Random.Range(t, randomQuestionLetters.Length);
			randomQuestionLetters[t]=randomQuestionLetters[r];
			randomQuestionLetters[r]=tmp;
		}
		indexRandomQuestionLetters=0;
	}

	public void reset () {
		this.userAnswer = 5;
		reshuffleRandomQuestionLetters();
		SetQuestion ();
		SetOption ();
		popUpAnswer.SetActive(false);
		popUpReward.SetActive(false);
		PlaySound();
	}

	public void PlaySound(){
		AudioManager.Instance.PlaySFXClip(questionAudio.clip);
	}
}
