using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverAsteroid : MonoBehaviour {

	Rigidbody2D rb;
	GameObject target;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag ("Player");
		if (target == null) target = GameObject.FindGameObjectWithTag ("Center");
		//Debug.Log (target.tag);
		rb.AddForce ((target.transform.position - transform.position).normalized * Random.Range(15f,40f));
	}



}
