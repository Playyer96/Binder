using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform wallGeneratorLeft;
	private Vector3 wallsStartPointLeft;
	public Transform wallGeneratorRight;
	private Vector3 wallsStartPointRight;

	public Character thePlayer;
	private Vector3 playerStartPoint;

	private WallDestroyer[] wallList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	void Start () {
		wallsStartPointLeft = wallGeneratorLeft.position;
		wallsStartPointRight = wallGeneratorRight.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	public void RestartGame(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);
		//StartCoroutine ("RestartGameCo");
	}

	public void Reset(){
		theDeathScreen.gameObject.SetActive (false);
		wallList = FindObjectsOfType<WallDestroyer> ();
		for (int i = 0; i < wallList.Length; i++) {
			wallList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		wallGeneratorLeft.position = wallsStartPointLeft;
		wallGeneratorRight.position = wallsStartPointRight;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
	/*public IEnumerator RestartGameCo(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		wallList = FindObjectsOfType<WallDestroyer> ();
		for (int i = 0; i < wallList.Length; i++) {
			wallList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		wallGeneratorLeft.position = wallsStartPointLeft;
		wallGeneratorRight.position = wallsStartPointRight;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
