using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour {

	public Text score;
	public string returnScene;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (PlayerPrefs.GetString ("Current_Level"));
		}
	}

	void Start() {
		score.text = "Final time: " + PlayerPrefs.GetInt ("Player Time").ToString () + " seconds";
	}
}
