using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleCinematic1 : MonoBehaviour {

	public AudioSource m_AudioSource;
	bool m_playSplash;
	int m_i;

	void Start () {
		m_playSplash = false;
	}

	void Update () {
		if (m_playSplash) {
			playSound ();
		}
	}


	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Splash") {
			Debug.Log ("should make splash sfx");
			m_playSplash = true;
		}
	}

	void playSound ()
	{
		if (!m_AudioSource.isPlaying && m_i == 0) {
			m_AudioSource.Play ();
			m_i++;
		}
	}
}
