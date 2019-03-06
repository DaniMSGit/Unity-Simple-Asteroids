using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard1;
	public GameObject hazard2;
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public GameObject ovni;

	public Vector3 spawnValue;
	public Vector3 spawnValueOvni;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float wavesWait;
	public float spawnWaitOvni;
	public float startWaitOvni;
	public Text scoreText;
	public static int score;
	public static int lifes;
	private Vector3 spawnPosition;
	private Vector3 spawnPositionOvni;


	void Start () {

		lifes = 3;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());
		StartCoroutine (SpawnOvnis());
	}

	IEnumerator SpawnOvnis() {
		
		yield return new WaitForSeconds (startWaitOvni);
		while (true) {
			float r = Random.Range (0, 1f);
			if (r > 0.5f) {
				spawnPositionOvni = new Vector3 (-spawnValueOvni.x, spawnValueOvni.y - Random.Range(0.1f,1f), spawnValueOvni.z);
			} else {
				spawnPositionOvni = new Vector3 (spawnValueOvni.x,  spawnValueOvni.y - Random.Range(0.1f,1f), spawnValueOvni.z);
			}
			Quaternion spawnRotationOvni = Quaternion.identity;
			Instantiate (ovni, spawnPositionOvni, spawnRotationOvni);
			yield return new WaitForSeconds (spawnWaitOvni);
		}
	}
	
	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				float r = Random.Range (0, 1f);
				if (r > 0.5f)
					spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				else
					spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), -spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				r = Random.Range (0, 1f);
				if (r > 0.5f) {
					GameObject h = Instantiate (hazard1, spawnPosition, spawnRotation);
					h.transform.localScale = Vector3.one * Random.Range(3f,8f);
				} else { 
					GameObject h = Instantiate (hazard2, spawnPosition, spawnRotation);
					h.transform.localScale = Vector3.one * Random.Range(3f,8f);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (wavesWait);
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	public void RemoveLife(){
		if (lifes != 0) lifes -= 1;
		if (lifes == 2) {
			life3.gameObject.SetActive (false);
		} else if (lifes == 1) {
			life2.gameObject.SetActive (false);
		} else if (lifes == 0) {
			//SceneManager.LoadScene("Stage1");
		}
	}

	void UpdateScore(){

		string sscore = score.ToString();

		if (sscore.Length == 1) {
			scoreText.text = "0 " + "0 " + sscore [0];
		} else if (sscore.Length == 2) {
			scoreText.text = "0 " + sscore [0] + " " + sscore [1];
		} else {
			scoreText.text = sscore [0] + " " + sscore [1] + " " + sscore [2];
		}
	}
}
