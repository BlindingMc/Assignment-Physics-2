using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSoundEffect : MonoBehaviour {

	public AudioSource m_audiosource; 
	public AudioClip m_hit;
	bool m_alreadyHit;

	void Start () {
		m_alreadyHit = false;
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player" && !m_alreadyHit) {
			playSound (m_hit);
			m_alreadyHit = true;
			Invoke ("ResetSound", 0.3f);
		}
	}

	void ResetSound () {
		m_alreadyHit = false;
	}

	public void playSound (AudioClip sfx)
	{
		m_audiosource.clip = sfx;

		m_audiosource.Play ();
	}
}
