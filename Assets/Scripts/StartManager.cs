using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	// Use this for initialization
	private IEnumerator Start () {
		DataManager.Init();

		//wait for data manager to load everything
		yield return StartCoroutine(DataManager.DownloadData("0", DataManager.ProcessLocalization) );

		yield return StartCoroutine(DataManager.DownloadData("1517523866", DataManager.ProcessAsteroids) );

		yield return StartCoroutine(DataManager.DownloadData("197558985",DataManager.ProcessConstants));

	//	Debug.LogFormat("Our speed is {0}",DataManager.GetConstant<float>("PlayerSpeed"));

		//load our actual game scene
		Debug.Log("Finished loading data, switching scenes");
		SceneManager.LoadScene("Main_Menu");
	}
}
