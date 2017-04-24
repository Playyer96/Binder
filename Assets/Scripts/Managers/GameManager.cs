using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform wallGenerator;
	private Vector3 wallsStartPoint;

	public Character thePlayer;
	private Vector3 playerStartPoint;

	private WallDestroyer[] wallList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

    [SerializeField]
    private GameObject highScoreTexts;

	void Start () {
		wallsStartPoint = wallGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	public void RestartGame(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);
        theScoreManager.NewHighScore();
        highScoreTexts.gameObject.SetActive(true);

	}

	public void Reset(){
		theDeathScreen.gameObject.SetActive (false);
		wallList = FindObjectsOfType<WallDestroyer> ();
		for (int i = 0; i < wallList.Length; i++) {
			wallList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		wallGenerator.position = wallsStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
}
