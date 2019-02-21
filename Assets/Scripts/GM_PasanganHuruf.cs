using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GM_PasanganHuruf : MonoBehaviour {

	[SerializeField]
	private Sprite[] upLatters;

	[SerializeField]
	private Sprite[] lowLatters;

	[SerializeField]
	private AudioClip[] soundLatters;

	[SerializeField]
	private AudioSource soundLatter;

	[SerializeField]
	private GameObject[] options;

	private int[] randomUpLatters;
	private int[] randomLowLatters;

	private int[] answer;
	private int[] userAnswer;
	private int indexUserAnswer;

	private int mainNumber;
	private int playTime;

	[SerializeField]
	private GameObject popUpAnswer;

	[SerializeField]
	private GameObject popUpReward;

	// Use this for initialization
	void Start () {
		answer = new int[2];
		userAnswer = new int[2];
		indexUserAnswer = 0;
		playTime=0;
		setRandomArray();
		reset();
	}
	
	// Update is called once per frame
	void Update () {
		if(!popUpAnswer.active && !popUpReward.active){
			CheckAnswer();
		}
	}

	private void setRandomArray(){
		randomLowLatters = new int[lowLatters.Length];
		randomUpLatters = new int[upLatters.Length];
		for(int i =0; i<upLatters.Length;i++){
			randomLowLatters[i]=i;
			randomUpLatters[i]=i;
		}
	}

	private void SetQuestion () {
		mainNumber = Random.Range (0, upLatters.Length);
		soundLatter.clip = soundLatters[mainNumber];
	}

	private void SetAnswer(){
		int i=0; int indexAnswer;
		do{
			indexAnswer = Random.Range(0, options.Length);
			if (!answer.Contains(indexAnswer)){
				answer[i]=indexAnswer;
				if (i == 0){
					options[indexAnswer].transform.GetChild(0).GetComponent<Image>().sprite=upLatters[mainNumber];
				}else{
					options[indexAnswer].transform.GetChild(0).GetComponent<Image>().sprite=lowLatters[mainNumber];
				}
				options[indexAnswer].transform.GetChild(0).GetComponent<Image>().SetNativeSize();
				i++;
			}
		}while(i != 2);
	}

	private void SetOptions(){
		SetAnswer();
		int indexUp=0; int indexLow=0;
		for (int i = 0; i<options.Length;i++){
			if(i != answer[0] && i != answer[1]){
				if ((Random.Range(0,100)%2) == 0){
					indexUp++;
					if(randomUpLatters[indexUp] == mainNumber){
						indexUp++;
					}
					options[i].transform.GetChild(0).GetComponent<Image>().sprite=upLatters[randomUpLatters[indexUp]];
				}else{
					indexLow++;
					if(randomLowLatters[indexLow] == mainNumber){
						indexLow++;
					}
					options[i].transform.GetChild(0).GetComponent<Image>().sprite=lowLatters[randomLowLatters[indexLow]];
				}
			}
			options[i].transform.GetChild(0).GetComponent<Image>().SetNativeSize();
			options[i].GetComponent<Image>().color = new Color32(255,255,255,255);
		}
	}

	public void GiveAnswer(int userAnswer){
		if(!this.userAnswer.Contains(userAnswer)){
			if(indexUserAnswer < 2){
				this.userAnswer[indexUserAnswer]=userAnswer;
				indexUserAnswer++;
				options[userAnswer].GetComponent<Image>().color = new Color32(22,192,216,255);
			}
		}else{
			if (indexUserAnswer > 0){
				indexUserAnswer--;
				this.userAnswer[indexUserAnswer]=-1;
			}
			options[userAnswer].GetComponent<Image>().color = new Color32(255,255,255,255);
		}
		Debug.Log(indexUserAnswer);
	}

	private void CheckAnswer () {
		if (answer.Contains(userAnswer[0]) && answer.Contains(userAnswer[1])) {
			playTime= playTime+1;
			StartCoroutine(showPopUp());
		}
	}

	private IEnumerator showPopUp(){
		if (playTime == 10){
			popUpReward.SetActive(true);
		}else{
			popUpAnswer.SetActive(true);
			yield return new WaitForSeconds(3);
			popUpAnswer.SetActive(false);
			reset();
		}
	}

	private void reshuffle()
    {
        for (int t = 0; t < randomUpLatters.Length; t++ )
        {
            int tmp = randomUpLatters[t];
            int r = Random.Range(t, randomUpLatters.Length);
            randomUpLatters[t] = randomUpLatters[r];
            randomUpLatters[r] = tmp;
        }

		for (int t = 0; t < randomLowLatters.Length; t++ )
        {
            int tmp = randomLowLatters[t];
            int r = Random.Range(t, randomLowLatters.Length);
            randomLowLatters[t] = randomLowLatters[r];
            randomLowLatters[r] = tmp;
        }
    }

	public void reset(){
		this.userAnswer[0]=-1;
		this.userAnswer[1]=-1;
		indexUserAnswer=0;
		reshuffle();
		SetQuestion();
		SetOptions();
		popUpAnswer.SetActive(false);
		popUpReward.SetActive(false);
		soundLatter.Play();
	}

	
}
