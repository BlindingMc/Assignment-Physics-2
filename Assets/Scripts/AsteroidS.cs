using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidS : MonoBehaviour {

	float m_rotation;
	float m_speed;
	Rigidbody m_rb;

	// Use this for initialization
	void Start () {
		m_rotation = 4.5f;
		m_speed = 0.15f;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.left * m_rotation);
		transform.Translate (Vector3.left * m_speed);
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	} 
}