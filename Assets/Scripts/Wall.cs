// Wall script

using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// wall property for left, right, and top walls
	public bool deadly = false;

	// player variable for deadly walls
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Collision handling
	// deadly wall will destroy a ball and send a LoseLife message to a player
	void OnCollisionEnter2D(Collision2D target) {
		// bottom wall
		if (deadly) {
			// destory a ball
			// parameter target is a game entity that collided. It's a ball.
			Destroy (target.gameObject);

			// check player variable is set. safety purpose
			if (player) 
				// send a LoseLife message (it calls the method, "LoseLife", defined in Player script
				player.SendMessage("LoseLife");
		}
	}
}
