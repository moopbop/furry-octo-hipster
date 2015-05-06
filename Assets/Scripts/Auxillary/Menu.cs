using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void Start() {
		Cursor.visible = true;
	}

	public void LoadScene(string id) {
		Application.LoadLevel (id);
	}

	public void Quit() {
		Application.Quit ();
	}
}
