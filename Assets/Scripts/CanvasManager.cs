using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	public void LevelOne () {
		SceneManager.LoadSceneAsync ("First_Level");
	}

	public void MainMenu () {
		SceneManager.LoadSceneAsync ("Main_Menu");
	}

	public void HowToPlay () {
		SceneManager.LoadSceneAsync ("How_To_Play");
	}

	public void Credits () {
		SceneManager.LoadSceneAsync ("Credits");
	}

	public void GameOver () {
		SceneManager.LoadSceneAsync ("Game_Over");
	}

	public void Win () {
		SceneManager.LoadSceneAsync ("Win_Screen");
	}


}
