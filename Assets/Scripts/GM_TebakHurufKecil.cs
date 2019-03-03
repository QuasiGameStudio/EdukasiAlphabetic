using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_TebakHurufKecil : MonoBehaviour {

	[SerializeField]
	private Sprite[] uplatters;

	[SerializeField]
	private Sprite[] lowlatters;

	[SerializeField]
	private Image questionImage;

	private int mainNumber;

	[SerializeField]
	private Image[] options;

	private int answer;
	private int userAnswer;

	private int playTime;

	private int[] randomUpLatters;
	private int[] randomQuestionLetters;

	private int indexRandomUpLetters;
	private int indexRandomQuestionLetters;

	[SerializeField]
	private GameObject popUpAnswer;

	[SerializeField]
	private GameObject popUpReward;

	[SerializeField]
	private GameObject blurImage;

	[SerializeField]
	private GameObject confetti;

	// Use this for initialization
	void Start () {
		playTime=0;
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
		mainNumber = randomUpLatters[indexRandomUpLetters];
		indexRandomUpLetters++;
		questionImage.sprite = uplatters[mainNumber];
	}

	private void SetOption () {
		answer = Random.Range (0, 3);
		options[answer].sprite = lowlatters[mainNumber];
		for (int i = 0; i < 3; i++) {
			int x= randomQuestionLetters[indexRandomQuestionLetters];
			indexRandomQuestionLetters++;
			if (i != answer) {
				if(x == mainNumber){
					x=randomQuestionLetters[indexRandomQuestionLetters];
					indexRandomQuestionLetters++;
				}
				options[i].sprite = lowlatters[x];
			}
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
		blurImage.SetActive(true);
		if (playTime == 10){
			confetti.SetActive(true);
			popUpReward.SetActive(true);
		}else{
			popUpAnswer.SetActive(true);
			yield return new WaitForSeconds(1);
			popUpAnswer.SetActive(false);
			blurImage.SetActive(false);
			reset();
		}
	}

	private void setRandomArray(){
		randomUpLatters = new int[uplatters.Length];
		randomQuestionLetters = new int[uplatters.Length];
		for (int i=0; i<uplatters.Length; i++){
			randomUpLatters[i]=i;
			randomQuestionLetters[i]=i;
		}
	}

	private void reshuffle(){
		for (int t = 0; t< randomUpLatters.Length; t++){
			int tmp = randomUpLatters[t];
			int r = Random.Range(t, randomUpLatters.Length);
			randomUpLatters[t]=randomUpLatters[r];
			randomUpLatters[r]=tmp;
		}
	}

	private void reshuffleRandomQuestionLetters(){
		for (int t = 0; t< randomQuestionLetters.Length; t++){
			int tmp = randomQuestionLetters[t];
			int r = Random.Range(t, randomQuestionLetters.Length);
			randomQuestionLetters[t]=randomQuestionLetters[r];
			randomQuestionLetters[r]=tmp;
		}
		Debug.Log(indexRandomQuestionLetters);
		indexRandomQuestionLetters=0;
	}

	public void reset () {
		this.userAnswer = 5;
		reshuffleRandomQuestionLetters();
		SetQuestion ();
		SetOption ();
		popUpAnswer.SetActive(false);
		popUpReward.SetActive(false);
		confetti.SetActive(false);
		blurImage.SetActive(false);
	}
}