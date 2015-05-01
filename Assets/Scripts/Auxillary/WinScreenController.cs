using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour {

	public Text score;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Main");
		}
	}

	void Start() {
		score.text = "Final time: " + PlayerPrefs.GetInt ("Player Time").ToString () + " seconds";
	}
}
