using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//pause functionality
	bool m_pause;
	public GameObject m_pauseCanvas; 
	public GameObject m_normalCanvas;

	// Use this for initialization
	void Start () {
		m_pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (!m_pause) {
				Pause ();
			} else {
				UnPause ();
			}
		}
	}

	public void Pause () {
		Time.timeScale = 0f;
		m_pauseCanvas.SetActive (true);
		m_normalCanvas.SetActive (false);
		m_pause = true;
	}

	public void UnPause () {
		Time.timeScale = 1.0f;
		m_pauseCanvas.SetActive (false);
		m_normalCanvas.SetActive (true);
		m_pause = false;
	}
}