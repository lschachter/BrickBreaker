using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (player) {
			//adds one to player's score
			player.SendMessage ("Score");
		}
		//destroys self on collision
		Destroy (gameObject);
	}
}
