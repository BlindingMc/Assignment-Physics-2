using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour {

	float m_rotation;

	// Use this for initialization
	void Start () {
		m_rotation = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * m_rotation * Time.deltaTime);
	}
}
