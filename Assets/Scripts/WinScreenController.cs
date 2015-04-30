using UnityEngine;
using System.Collections;

public class WinScreenController : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Main");
		}
	}
}
