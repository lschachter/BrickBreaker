// Player script

using UnityEngine;
using System.Collections;

// include UI module for score text
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// ball object
	public Ball ball;

	public AudioClip successSound;
	public AudioClip failureSound;

	// score ui
	public Text scoreUI;
	public Text livesUI;

	public Text gameOverText;
	private bool gameOver;

	// variables
	public float speed = 0.2f;
	public bool readytofire = false;
	private int score = 0;
	private int lives = 3;

	// key control variables
	public string upkey = "up";
	public string downkey = "down";
	public string firekey = "space";

	// Use this for initialization
	void Start () {
		gameOver = false;
		gameOverText.text = "";

		//if (readytofire)
		BallReady ();
	}

	// ready to serve a ball
	void BallReady() {
		readytofire = true;

		// toggel hidden game entity, BallPos
		// this is a trick to show a ball along with a player
		transform.Find("BallPos").gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		// check move keys
		if (Input.GetKey(upkey))
			transform.Translate (new Vector2(0, speed));
		else if (Input.GetKey(downkey))
			transform.Translate (new Vector2(0, -speed));

		// check fire key only if the player has the ball (service)
		if (readytofire) {
			if (Input.GetKey(firekey)) {
				FireBall ();
			}
		}
	}

	// launce a ball
	void FireBall() {
				
		// safe guard
		if (!ball) {
			return;
		}
		// create new ball
		Ball clone = Instantiate(ball, transform.Find("BallPos").position, Quaternion.identity) as Ball;

		// hide fake ball
		transform.Find("BallPos").gameObject.SetActive (false);

		// candidate ball moving angle for player 1 (left side one)
		float angle = Mathf.Deg2Rad * Random.Range (20, 70);

		// create vector2 for the angle
		Vector2 force = new Vector2(Mathf.Cos (angle), Mathf.Sin (angle));

		// a simple trick to check the player by checking its x position
		if (transform.position.x > 0)
				force.x = -force.x;

		//sets the clone's score and lives to know when to stop motion

		// apply initial force to rigidbody
		clone.GetComponent<Rigidbody2D>().AddForce (force*0.03f);

		// reset readytofire variable
		readytofire = false;
	}

	// player wins a point. this method is invoked by a deadly wall
	void Score() {

		// increment score
		score++;
	

		// apply change to score UI
		if (scoreUI)
			scoreUI.text = "Score \n"+score.ToString();
		if (score == 28)
			GameOver("You Win!",2);
	}

	void LoseLife(){


		lives--;

		if (livesUI) 
			livesUI.text = "Lives \n"+lives.ToString ();
		if (lives == 0) {
			GameOver ("Game Over!", 1);
		} else {
			BallReady ();
		}
	}
	

	public void GameOver (string how, int mood) {
		if (mood == 1)
			AudioSource.PlayClipAtPoint (failureSound, transform.position);
		else
			AudioSource.PlayClipAtPoint (successSound, transform.position);

		gameOverText.text = how;
		gameOver = true;
		//Destroy (ball.gameObject);
		ball.GetComponent<Rigidbody2D>().isKinematic = true;
	}

	void OnGUI(){
		if (gameOver) {
			if (GUI.Button (new Rect (100, 100, 200, 80), "Click to Exit")) {
					ball.GetComponent<Rigidbody2D> ().isKinematic = false;
					Application.Quit ();
			}
		}
	}
}
