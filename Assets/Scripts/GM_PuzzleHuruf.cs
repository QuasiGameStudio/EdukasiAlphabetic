using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_PuzzleHuruf : MonoBehaviour {


	[SerializeField]
	private Sprite[] uplatters;

	// [SerializeField]
	// private Sprite[] lowlatters;

	[SerializeField]
	private Image[] questionImage;

	private int[] mainNumber;

	[SerializeField]
	private Image[] options;

	// private int answer;
	// private int userAnswer;

	private int playTime;

	private int[] randomUpLatters;
	// private int[] randomQuestionLetters;

	private int indexRandomUpLetters;
	// private int indexRandomQuestionLetters;

	[SerializeField]
	private GameObject popUpAnswer;

	[SerializeField]
	private GameObject popUpReward;

	private int rightPoint;

	// Use this for initialization
	void Start () {
		playTime=0;
		mainNumber = new int[4];
		setRandomArray();
		reshuffle();
		reset ();
	}

	// Update is called once per frame
	void Update () {
		if (rightPoint == 4 && !popUpAnswer.activeSelf && !popUpReward.activeSelf){
			CheckAnswer();
		}
	}

	private void SetQuestion () {
		if (indexRandomUpLetters == randomUpLatters.Length){
			reshuffle();
		}
		for (int i = 0; i<4; i++){
			mainNumber[i] = randomUpLatters[indexRandomUpLetters];
			indexRandomUpLetters++;
			questionImage[i].sprite = uplatters[mainNumber[i]];
			questionImage[i].GetComponent<Tile_>().SetNumber(mainNumber[i]);
			questionImage[i].SetNativeSize ();
			// Debug.Log(i +" "+mainNumber[i]+" "+options.Length+" "+mainNumber.Length+" "+uplatters.Length);
			options[i].sprite=uplatters[mainNumber[i]];
			options[i].GetComponent<Tile_>().SetNumber(mainNumber[i]);
			options[i].SetNativeSize();
		}
	}

	private void SetOption () {
		for (int t = 0; t< 4; t++){
			options[t].GetComponent<Image>().enabled=true;
			Sprite tmpSprite = options[t].sprite;
			int tmpNumber = options[t].GetComponent<Tile_>().GetNumber();
			
			int r = Random.Range(t, 4);
			
			options[t].sprite = options[r].sprite;
			options[t].GetComponent<Tile_>().SetNumber(options[r].GetComponent<Tile_>().GetNumber());

			options[r].sprite = tmpSprite;
			options[r].GetComponent<Tile_>().SetNumber(tmpNumber);
		}
		// answer = Random.Range (0, 3);
		// options[answer].sprite = lowlatters[mainNumber];
		// options[answer].GetComponent<Tile_>().SetNumber(mainNumber);
		// Debug.Log(answer);
		// for (int i = 0; i < 3; i++) {
		// 	int x= randomQuestionLetters[indexRandomQuestionLetters];
		// 	indexRandomQuestionLetters++;
		// 	if (i != answer) {
		// 		if(x == mainNumber){
		// 			x=randomQuestionLetters[indexRandomQuestionLetters];
		// 			indexRandomQuestionLetters++;
		// 		}
		// 		options[i].sprite = lowlatters[x];
		// 		options[i].GetComponent<Tile_>().SetNumber(x);
		// 	}
		// 	options[i].SetNativeSize ();
		// }
	}

	public void IncreaseRightPoint(){
		rightPoint++;
	}

	public void CheckAnswer () {
		playTime= playTime+1;
		Debug.Log(playTime);
		Debug.Log ("nice");
		StartCoroutine(showPopUp());
	}

	private void setRandomArray(){
		randomUpLatters = new int[uplatters.Length];
		// randomQuestionLetters = new int[uplatters.Length];
		for (int i=0; i<uplatters.Length; i++){
			randomUpLatters[i]=i;
			// randomQuestionLetters[i]=i;
		}
	}

	private void reshuffle(){
		indexRandomUpLetters=0;
		for (int t = 0; t< randomUpLatters.Length; t+=4){
			int r = Random.Range(t, randomUpLatters.Length);
			for(int i = 0; i <4; i++){
				if ((t+i) < randomUpLatters.Length && (r+i)<randomUpLatters.Length){
					// Debug.Log("nilai t:"+t+"nilai i:"+i);
					int tmp = randomUpLatters[t+i];
					randomUpLatters[t+i]=randomUpLatters[r+i];
					randomUpLatters[r+i]=tmp;
				}
			}
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

	// private void reshuffleRandomQuestionLetters(){
	// 	for (int t = 0; t< randomQuestionLetters.Length; t++){
	// 		int tmp = randomQuestionLetters[t];
	// 		int r = Random.Range(t, randomQuestionLetters.Length);
	// 		randomQuestionLetters[t]=randomQuestionLetters[r];
	// 		randomQuestionLetters[r]=tmp;
	// 	}
	// 	Debug.Log(indexRandomQuestionLetters);
	// 	indexRandomQuestionLetters=0;
	// }

	public void reset () {
		// this.userAnswer = 5;
		rightPoint =0;
		// reshuffleRandomQuestionLetters();
		SetQuestion ();
		SetOption ();
		popUpAnswer.SetActive(false);
		popUpReward.SetActive(false);
	}
}
