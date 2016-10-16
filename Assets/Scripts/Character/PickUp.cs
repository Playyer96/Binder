using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	[SerializeField]
	private int scoreToGive;

	private ScoreManager theScoreManager;

	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Character") {
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
		}
	}
}
