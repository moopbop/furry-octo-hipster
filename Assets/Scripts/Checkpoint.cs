using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public bool destroyed;

	void Start() {
		destroyed = false;
	}

	void Update () {
		float time = Time.deltaTime * 35;
		transform.Rotate (Vector3.up, 5 + time);
		transform.Rotate (Vector3.right, 2 + time);
	}
}
