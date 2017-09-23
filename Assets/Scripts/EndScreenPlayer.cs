using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenPlayer : MonoBehaviour {

	Rigidbody m_rb;
	float m_force;
	float m_turnForce;
	float m_jumpForce;

	// Use this for initialization
	void Start () {
		m_rb = GetComponent <Rigidbody> ();
		m_force = 3.0f;
		m_turnForce = 20.0f;
		m_jumpForce = 50.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			gameObject.transform.Translate (Vector3.back * m_force * Time.deltaTime);
		} if (Input.GetKey (KeyCode.S)) {
			gameObject.transform.Translate (Vector3.forward * m_force * Time.deltaTime);
		} if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.Rotate (Vector3.down * m_turnForce * Time.deltaTime);
		} if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.Rotate (Vector3.up * m_turnForce * Time.deltaTime);
		} if (Input.GetKey (KeyCode.Space)) {
			m_rb.AddForce (Vector3.up * m_jumpForce);
		}
	}
}
