﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour {

	public Text score;			// Score display
	public string returnScene;	// Scene to return to if "R" pressed

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (PlayerPrefs.GetString ("Current_Level"));
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			Application.LoadLevel ("MainMenu");
		}
	}

	void Start() {
		score.text = "Final time: " + PlayerPrefs.GetInt ("Player Time").ToString () + " seconds";
	}
}
