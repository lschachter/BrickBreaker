// Ball script

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioClip collisionSound;
	public AudioClip brickBreakSound;


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().isKinematic = false;
	}

	// Update is called once per frame
	void Update () {


	}

	// Collision handling: make a bouncing sound when hit a wall
	void OnCollisionEnter2D(Collision2D target) {
		// safeguard: check if the audio clip is assigned
		if (brickBreakSound && target.gameObject.name.Contains ("Brick")) {
				// simple audio clip playback
				AudioSource.PlayClipAtPoint (brickBreakSound, transform.position);
		} else {
				AudioSource.PlayClipAtPoint (collisionSound, transform.position);
		}
	}
}
