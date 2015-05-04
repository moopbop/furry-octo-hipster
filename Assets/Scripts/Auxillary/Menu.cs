using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void LoadScene(string id) {
		Application.LoadLevel (id);
	}

	public void Quit() {
		Application.Quit ();
	}
}
