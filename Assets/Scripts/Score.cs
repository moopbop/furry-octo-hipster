using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	Text score;

	void Start() {
		score = GetComponent<Text> ();
		score.text = "Final time: " + PlayerPrefs.GetInt ("Player Time").ToString () + " seconds";
	}
}
