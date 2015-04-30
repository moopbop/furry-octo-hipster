using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	#region public variables
	public Transform[] positions;		// Places to instantiate checkpoints
	public GameObject checkpointPrefab;	// Prefab to use for instantiation
	public bool[] destroyed;			// Parallel to checkpoints : if index collected
	public GameObject[] checkpoints;	// Stores instantiated checkpoints
	#endregion

	void Start() {
		checkpoints = new GameObject[positions.Length];
		destroyed = new bool[checkpoints.Length];

		for (int i = 0; i < positions.Length; i++) {
			GameObject o = Instantiate (checkpointPrefab, positions[i].position, positions[i].rotation) as GameObject;
			checkpoints[i] = o;
		}
	}

	public int GetIndexByPosition(Vector3 position) {
		for (int i = 0; i < checkpoints.Length; i++) {
			if (checkpoints[i].transform.position == position) {
				return i;
			}
		}

		return -1;
	}
}
