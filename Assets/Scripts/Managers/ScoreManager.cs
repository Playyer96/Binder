using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText;
	[SerializeField]
	private Text[] highScoreTexts;

	private float highScore1;
    private float highScore2;
    private float highScore3;

    [SerializeField]
	private float pointsPerSecond;

	public float scoreCount;
	public bool scoreIncreasing;

	void Start(){
		if (PlayerPrefs.HasKey ("HighScore1")) {
			highScore1 = PlayerPrefs.GetFloat ("HighScore1");
		}
        if (PlayerPrefs.HasKey("HighScore2"))
        {
            highScore2 = PlayerPrefs.GetFloat("HighScore2");
        }
        if (PlayerPrefs.HasKey("HighScore3"))
        {
            highScore3 = PlayerPrefs.GetFloat("HighScore3");
        }
    }

	void Update(){
		if (scoreIncreasing) {
            ScoreIncreasing();
        }
        ScoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
	public void AddScore(int pointsToAdd){
		scoreCount += pointsToAdd;
	}

    private void ScoreIncreasing()
    {
        scoreCount += pointsPerSecond * Time.deltaTime;
    }

    public void NewHighScore()
    {
        highScoreTexts[0].text = "High Score 1: " + Mathf.Round(highScore1);
        highScoreTexts[1].text = "High Score 2: " + Mathf.Round(highScore2);
        highScoreTexts[2].text = "High Score 3: " + Mathf.Round(highScore3);
        if (scoreCount > highScore1)
        {
            highScore1 = scoreCount;
            PlayerPrefs.SetFloat("HighScore1", highScore1);
            highScoreTexts[0].text = "High Score 1: " + Mathf.Round(highScore1);
            scoreCount = 0;
        }
        if (scoreCount > highScore2)
        {
            highScore2 = scoreCount;
            PlayerPrefs.SetFloat("HighScore2", highScore2);
            highScoreTexts[1].text = "High Score 2: " + Mathf.Round(highScore2);
            scoreCount = 0;
        }
        if (scoreCount > highScore3)
        {
            highScore3 = scoreCount;
            PlayerPrefs.SetFloat("HighScore3", highScore3);
            highScoreTexts[2].text = "High Score 3: " + Mathf.Round(highScore3);
            scoreCount = 0;
        }
    }
}
