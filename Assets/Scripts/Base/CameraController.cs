using UnityEngine;
using System.Collections;

/*
 * CameraController.cs
 * Initializes camera in spot designated by values (in-editor)
 * By: Patrick Bartlett on 4/22/2015
 */
public class CameraController : MonoBehaviour {

	#region public variables
	public Transform follow;
	public float distance;
	public float up;
	public float maxUpAngle;
	public float maxDownAngle;
	public float msSensitivity;
	#endregion

	#region system voids
	void Start() {
		this.transform.position = follow.position + new Vector3 (0, up, -distance);
	}

	void Update() {
		float mouseY = Input.GetAxis ("Mouse Y");
		this.transform.Rotate (Vector3.left, (mouseY * msSensitivity * Time.deltaTime));
	}
	#endregion
}
