﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

	public void RestartScene(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
