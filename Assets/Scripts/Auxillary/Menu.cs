using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void LoadScene() {
		Application.LoadLevel ("Main");
	}

	public void Quit() {
		Application.Quit ();
	}
}
