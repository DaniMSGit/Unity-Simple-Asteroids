using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShotOvni : MonoBehaviour {

	Rigidbody2D rb;
	GameObject target;
	public float speed;
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag ("Player");
		if (target == null) target = GameObject.FindGameObjectWithTag ("Center");
		rb.AddForce ((target.transform.position - transform.position).normalized * speed);
	}



}
