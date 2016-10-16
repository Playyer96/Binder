using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame(){
		SceneManager.LoadScene (playGameLevel);
	}
	public void QuitGame(){
		Application.Quit ();
	}
}
