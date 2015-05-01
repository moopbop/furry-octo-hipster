using UnityEngine;
using System.Collections;

/*
 * CameraController.cs
 * Initializes camera in spot designated by values (in-editor)
 * By: Patrick Bartlett on 4/22/2015
 */
public class CameraController : MonoBehaviour {

	public Transform follow;
	public float distance;
	public float up;

	void Start() {
		transform.position = follow.position + new Vector3 (0, up, -distance);
	}
}
