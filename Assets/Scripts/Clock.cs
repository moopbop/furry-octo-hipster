using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
	DateTime time;
	int seconds;

	void Start() {
		time = DateTime.Now;
		seconds = 0;
	}

	void Update() {
		seconds = ((time.Minute * 60 - DateTime.Now.Minute * 60) + (time.Second - DateTime.Now.Second)) * -1;
	}

	// Draw important things to the screen
	void OnGUI() {
		GUI.Label (new Rect(Screen.width - 30, 10, 150, 150), seconds.ToString ());
	}

	public void Reset() {
		time = DateTime.Now;
		seconds = 0;
	}

	public int GetSeconds() {
		return seconds;
	}
}
