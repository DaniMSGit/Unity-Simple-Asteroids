using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvniScript : MonoBehaviour {

	public GameObject shot;
	public GameObject EnemyExplosion;
	public Transform shotSpawn;
	public int scorevalue;
	public float startWaitShoot;
	public float spawnWaitShoot;
	private GameController gameController;



	// Use this for initialization

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}else Debug.Log("Not exist GameController");
		StartCoroutine (shooting ());
	}


	IEnumerator shooting() {

		yield return new WaitForSeconds (startWaitShoot);
		while (true) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			yield return new WaitForSeconds (spawnWaitShoot);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "shot") {
			//Instantiate (EnemyExplosion, transform.position,transform.rotation);
			gameController.AddScore (scorevalue);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

		if (other.tag == "Player") {
			//Instantiate (EnemyExplosion, other.transform.position, other.transform.rotation);
			gameController.RemoveLife ();
			Destroy (gameObject);
		}
			
	}
		
}
