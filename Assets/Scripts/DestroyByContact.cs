using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This scripts is applied to the asteroids to simulate the 
 *  collisions with the player and the firings of this one.
 */

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;                //Reference to gameObject 'Explosion'.
	public GameObject playerExplosion;          //Reference to gameObject 'Explosion'.
	public int scorevalue;                      //Score for this kind of asteroids.
	private GameController gameController;      //Reference to gameObject 'GameController'

	/** When the object is initialized we look for the object 'GameController' 
	 *  in the game to be able to update the scores and the number of lives.
	 */
	void Start(){

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}else Debug.Log("Not exist GameController");
	}

	/** This event triggers when an object enters the edge of collisions, 
	 *  obtaining a reference to the object that has collided. When an 
	 *  asteroid collides with the player the number of lives is updated, 
	 *  when it hits the player's shot the score is updated.
	 */

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Boundary" || other.tag == "Asteroid" || other.tag == "ovni" || other.tag == "shot2") return;

		//Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);

		if (other.tag == "Player") {
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.RemoveLife ();
		}

		if (other.tag != "Player") {
			Destroy (other.gameObject);
			gameController.AddScore (scorevalue);
		}

	}
		
		
}
