﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidM : MonoBehaviour {

	float m_rotation;
	float m_rotation2;
	Rigidbody m_rb;

	// Use this for initialization
	void Start () {
		m_rotation = 3.3f;
		m_rotation2 = 1.6f;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.left * m_rotation);
		transform.Rotate (Vector3.up * m_rotation2);
	}
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	} 
}