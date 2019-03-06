using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This scripts is applied to the object of the game 'boundary' 
 * its function is to destroy the asteroids and UFOs that leave 
 * the limit of the screen.
 */

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "ovni") {
			Destroy (other.gameObject);
		}
			
	}
}
