using UnityEngine;
using System.Collections;

/*
 * PlayerController.cs
 * Handles player movement and jetpack mechanics
 * By: Patrick Bartlett on 4/22/2015
 */
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	#region public variables
	/* Public variables */
	public float speed;						// X/Z speed modifier
	public float boostSpeed;				// Y speed modifier
	public float killY;						// Y kill depth
	public float turnSpeed;
	public float maxGroundSpeed;			// X/Z clamping value
	public float maxAirSpeed;				// Y clamping value
	public float jetLimit;					// Y accel limiter
	public GameObject checkpointManager;	// Reference checkpoint controller
	public AudioSource collect;
	public AudioSource die;
	public AudioSource win;
	public ParticleSystem[] jet_particles;	// Array of jetpack particles
	public GameObject timer;
	#endregion

	#region private variables
	/* Private variables */
	private Vector3 input;								// Input reading during Update()
	private Vector3 startPosition;						// For easy resets
	private Rigidbody rb;
	private float jetCount;								// Y accel clamp
	private CheckpointController checkControl;			// CheckpointController.cs script
	private int checkCount;								// Checkpoint counter
	private bool endGame;
	#endregion
	
	/* Methods & functions */
	void Start() {
		rb = GetComponent<Rigidbody> ();
		startPosition = rb.position;
		jetCount = 0;
		checkControl = checkpointManager.GetComponent<CheckpointController> ();
		checkCount = 0;
		endGame = false;

		// Hide cursor
		Cursor.visible = false;
	}
	
	void Update() {

		// Check for win and song over
		if (endGame && !win.isPlaying) {
			// Load end scene (index 1 as-of 4/26/2015)
			PlayerPrefs.SetInt ("Player Time", timer.GetComponent<Clock>().GetSeconds ());
			Application.LoadLevel ("AlphaWin");
		}
		
		// Grab input from all relevant axes
		input = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Jump"), Input.GetAxis ("Vertical"));

		// Key input
		if (Input.GetKeyDown (KeyCode.R)) {
			Die ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

		// Mouse input
		if (Input.GetMouseButton (0)) {	// Left mouse
			rb.transform.Rotate (Vector3.down, turnSpeed * Time.deltaTime);	// Rotate left
		}
		if (Input.GetMouseButton(1)) {	// Right mouse
			rb.transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);	// Rotate right
		}

		// Y depth insurance
		if (rb.transform.position.y <= killY) {
			Die ();
		}

		// Particles
		if (Input.GetKey (KeyCode.Space)) {
			for (int i = 0; i < jet_particles.Length; i++) {
				if (jet_particles[i].isStopped) {
					jet_particles[i].Play ();
				}
			}
		}
	}

	/* Every frame */
	void FixedUpdate() {
		Vector3 force = new Vector3 (input.x * speed, input.y * boostSpeed, input.z * speed);	// Separate x/z and y speeds

		if (force.y >= 1 && jetCount < jetLimit) {
			jetCount+= 2f;
		}

		if (jetCount >= jetLimit) {
			force.y = 0;
		}

		rb.AddRelativeForce (force);	// Applies relative to rotation

		// Speed clamping. Allows a higher speed value for more responsive movement
		Vector3 vel = rb.velocity;
		if (vel.x > maxGroundSpeed) {
			vel.x = maxGroundSpeed;
		}
		if (vel.z > maxGroundSpeed) {
			vel.z = maxGroundSpeed;
		}
		rb.velocity = vel;

		if (jetCount > 0)
			jetCount--;

		if (jetCount < 0)
			jetCount = 0;
	}

	/* Collision initiated */
	void OnTriggerEnter(Collider c) {
			 
		string tag = c.gameObject.tag;

		if (tag == "Checkpoint") {
			int hitIndex = checkControl.GetIndexByPosition (c.gameObject.transform.position);

			if (hitIndex != -1) {
				collect.Play ();
				checkControl.checkpoints[hitIndex].SetActive(false);
				checkControl.destroyed[hitIndex] = true;
				checkCount++;
			}

			endGame = true;

			// If any checkpoints aren't cleared, don't end the game
			// This saves us from checking for win on update (which may massacare framerates)
			for (int i = 0; i < checkControl.destroyed.Length; i++) {
				if (checkControl.destroyed[i] == false)
					endGame = false;
			}

			if (endGame) {
				// Victory music
				win.Play ();
			}
		}
	}

	/* Reset pertinent values */
	void Die() {

		// Player
		rb.rotation = Quaternion.identity;
		rb.velocity = new Vector3 (0, 0, 0);
		rb.position = startPosition;
		jetCount = 0;
		checkCount = 0;
		die.Play ();

		// Checkpoints
		for (int i = 0; i < checkControl.checkpoints.Length; i++) {
			checkControl.checkpoints[i].SetActive (true);
			checkControl.destroyed[i] = false;
		}

		// Reset time
		timer.GetComponent<Clock> ().Reset ();
	}

	// Draw important things to the screen
	void OnGUI() {
		GUI.Label (new Rect(10, 10, 150, 150), "Checkpoints: " + checkCount.ToString() + " / " + checkControl.checkpoints.Length.ToString());
		GUI.Label (new Rect(10, Screen.height - 30, 150, 150), "Fuel: " + jetCount.ToString () + " / " + jetLimit.ToString ());
	}
}
