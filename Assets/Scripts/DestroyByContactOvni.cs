using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This scripts is applied to the shot2 of UFO to simulate the 
 *  collisions with the player.
 */

public class DestroyByContactOvni : MonoBehaviour {

	public GameObject playerExplosion;      //Reference to gameObject 'Explosion'.
	private GameController gameController;  //Reference to gameObject 'GameController'

	/** When the object is initialized we look for the object 'GameController' 
	 *  in the game to be able to update the number of lives. When the shot 
	 *  collides with the player updates the lives of this.
	 */
	void Start(){

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}else Debug.Log("Not exist GameController");
	}

	/** This event triggers when an object enters the edge of collisions, 
	 *  obtaining a reference to the object that has collided.
	 */
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Boundary" || other.tag == "Asteroid" || other.tag == "ovni" || other.tag == "shot") return;
		Destroy(gameObject);

		if (other.tag == "Player") {
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.RemoveLife ();
		}
			
	}
}
