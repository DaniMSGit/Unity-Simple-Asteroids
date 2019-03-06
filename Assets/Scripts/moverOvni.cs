using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverOvni : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		if (rb.transform.position.x > 0) {
			rb.velocity = -transform.right * speed;
		}else rb.velocity = transform.right * speed;
	}
	

}
