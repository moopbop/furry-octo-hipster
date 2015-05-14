using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	public bool destroyed;	// Whether or not to exist

	void Start() {
		destroyed = false;
	}

	void Update () {

		// Pesudo-random rotation speeds for variation
		float up = Time.deltaTime * Random.Range (25f, 100f);
		float right = Time.deltaTime * Random.Range (25f, 100f);
		transform.Rotate (Vector3.up, 5 + up);
		transform.Rotate (Vector3.right, 2 + right);
	}
}
