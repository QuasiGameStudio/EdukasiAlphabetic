using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_ : MonoBehaviour {

	[SerializeField]
	private bool isTarget;

	[SerializeField]
	private int number;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GetIsTarget(){
		return isTarget;
	}

	public int GetNumber(){
		return number;
	}

	public void SetNumber(int number){
		this.number = number;
	}
}
