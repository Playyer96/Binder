using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText;
	[SerializeField]
	private Text highScoreText;

	[SerializeField]
	private float highScoreCount;

	[SerializeField]
	private float pointsPerSecond;

	public float scoreCount;
	public bool scoreIncreasing;

	void Start(){
		if (PlayerPrefs.HasKey ("HighScore")) {
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}

	void Update(){
		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);
		}
		ScoreText.text = "Score: " + Mathf.Round(scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
	}
	public void AddScore(int pointsToAdd){
		scoreCount += pointsToAdd;
	}
}
