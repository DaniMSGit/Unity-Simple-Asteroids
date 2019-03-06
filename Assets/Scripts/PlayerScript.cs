using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public float leftc;
	public float rightc;
	public float bottomc;
	public float topc;
	//private int count = 0;

	private int noshotcount = 0;

	void Start () {
		
		Screen.SetResolution(128, 128, false);
		rb = GetComponent<Rigidbody2D> ();
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

	void FixedUpdate(){
		//Debug.Log ("NAVE: " + System.DateTime.Now.ToString ("h:mm:ss.fff tt"));
		if (MainControl.Updateaction == true || MainControl.ManualControl == true) {
			adjustPos ();
			actions ();	
			MainControl.fixedupdate = true;
		}

	}


	void actions (){


		if (MainControl.ManualControl == true) {

			if (Input.GetAxis ("Horizontal") < 0)
				transform.Rotate (Vector3.forward * 4f);

			if (Input.GetAxis ("Horizontal") > 0)
				transform.Rotate (Vector3.back * 4f);

			if (Input.GetAxis ("Vertical") > 0) {
				if (rb.velocity.magnitude < 2) {
					rb.AddForce (transform.up * 3f);
				}
			}

			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}

		} else {
			
				MainControl.Updateaction = false;
				//Debug.Log ("Action:" + MainControl.action);
				//count += 1;
				//Debug.Log (count);
				//Debug.Log (transform.position.x + "-" + transform.position.y);
				
				//if (noshotcount != 0 && MainControl.action != 3) noshotcount = noshotcount - 1;
					
				switch (MainControl.action) {
					case 0:
						transform.Rotate (Vector3.forward * 4f);
						break;
					case 1:
						transform.Rotate (Vector3.back * 4f);
						break;
					case 2:
						if (rb.velocity.magnitude < 1.5) {
							rb.AddForce (transform.up * 3f);
						}
						break;
					case 3:
						/*if (noshotcount == 0) {
							Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
							noshotcount = 5;
						} else {
							noshotcount = noshotcount - 1;
						}*/
						if (Time.time > nextFire) {
							nextFire = Time.time + fireRate;
							Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						}
						break;
					default:
						break;
				}

		}

		rb.velocity = rb.velocity * 0.99f;
		rb.angularVelocity = rb.angularVelocity * 0.99f;
    }

}
