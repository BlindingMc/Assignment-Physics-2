using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	public void LevelOne () {
		SceneManager.LoadSceneAsync ("Scenes/Levels/First_Level");
		Time.timeScale = 1.0f;
	}

	public void MainMenu () {
		SceneManager.LoadSceneAsync ("Scenes/BootScreen");
	}

	public void HowToPlay () {
		SceneManager.LoadSceneAsync ("Scenes/Menus & Other/How_To_Play");
	}

	public void Credits () {
		SceneManager.LoadSceneAsync ("Scenes/Menus & Other/Credits");
	}

	public void GameOver () {
		SceneManager.LoadSceneAsync ("Scenes/Menus & Other/Game_Over");
	}

	public void LevelTwo () {
		SceneManager.LoadSceneAsync ("Scenes/Levels/Second_Level");
	}
	public void CinematicOne () {
		SceneManager.LoadSceneAsync ("Scenes/Cinematics/Cinematic_1");
	}
}
