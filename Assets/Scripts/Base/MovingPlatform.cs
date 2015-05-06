using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform target;
	public float speed;
	public Transform start;
	private bool direction;

	void Start() {
		direction = false;
	}

	void Update() {
		float step = speed * Time.deltaTime;

		if (direction == false) {
			Vector3 nextPos = Vector3.MoveTowards (this.transform.position, target.position, step);

			if (nextPos != target.position) {
				this.transform.position = nextPos;
			}
			else {
				direction = true;
			}
		}

		if (direction == true) {
			Vector3 nextPos = Vector3.MoveTowards (this.transform.position, target.position, -step);

			if (nextPos != start.position) {
				this.transform.position = nextPos;
			}
			else {
				direction = false;
			}
		}

		Debug.Log (start.position);
	}
}