using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public float leftc;
	public float rightc;
	public float bottomc;
	public float topc;
	Vector3 lastPos;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}

	void FixedUpdate(){
		adjustPos ();
	}



	void adjustPos(){

		Vector3 newPos = transform.position;
		if (transform.position.y > topc) {
			newPos.y = bottomc;
		}

		if (transform.position.y < bottomc) {
			newPos.y = topc;
		}
		if (transform.position.x > rightc) {
			newPos.x = leftc;
		}
		if (transform.position.x < leftc) {
			newPos.x = rightc;
		}
		transform.position = newPos;

	}

}
