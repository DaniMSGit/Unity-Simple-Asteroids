using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**This script is applied to the shots of both the player and the UFO. 
 * It limits the life time of this, after that time they are destroyed.
 */ 
public class DestroyByTime : MonoBehaviour {

	public float lifetime;

	void Start () {
		Destroy (gameObject, lifetime);
	}

}
