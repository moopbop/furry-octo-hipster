using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public bool destroyed;

	void Start() {
		destroyed = false;
	}

	void Update () {
		transform.Rotate (Vector3.up, 5f * Time.deltaTime);
		transform.Rotate (Vector3.right, 2f * Time.deltaTime);
	}
}
