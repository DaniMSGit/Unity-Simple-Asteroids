using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script is applied to the asteroids of the game to simulate the 
 *  typical rotational movement that occurs when moving.
 */

public class AsteroidRotation : MonoBehaviour {

	Rigidbody2D rb;    

	/**
	 * When the object is initialized a random angular velocity 
	 * is applied to its 'rigidbody' of the asteroid.
	 */

	void Start () {
		 
		rb = GetComponent<Rigidbody2D> ();
		rb.angularVelocity = Random.Range(30f,150f);
	}

}
