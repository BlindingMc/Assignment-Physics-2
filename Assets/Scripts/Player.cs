using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	Rigidbody m_rb; 
	//forces
	float m_force;
	float m_adjust;
	float m_slow;

	//canvas
	public Text m_scoreText;
	public Text m_speedText;
	public Text m_healthText;

	//particles

	//extra variables
	int m_score;
	bool m_goForward;
	int m_health = 3;

	// Use this for initialization
	void Start () {
		m_rb = GetComponent <Rigidbody> ();
		m_force = 200.0f;
		m_adjust = 1000.0f;
		m_slow = -50.0f;
		m_goForward = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//health.. win/ loss condition
		if (m_health == 0) {
			SceneManager.LoadSceneAsync ("Game_Over");
		}

		//input
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (m_rb.velocity.z <= 15) {
				m_rb.AddForce (Vector3.forward * m_force * Time.deltaTime);
				m_goForward = true;
			}
		}
		if (m_rb.velocity.z <= 15) {
			m_speedText.text = "" + m_rb.velocity.z;
		} else {
			m_speedText.text = "Maximum Power !!1!";
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			m_goForward = false;
		}
		if (Input.GetKey (KeyCode.A)) {
			m_rb.AddForce (Vector3.left * m_adjust * Time.deltaTime);
//			m_fireRight.Play ();
		}
		if (Input.GetKeyUp (KeyCode.A)) {
		}
		if (Input.GetKey (KeyCode.D)) {
			m_rb.AddForce (Vector3.right * m_adjust * Time.deltaTime);
		} 
		if (Input.GetKeyUp (KeyCode.D)) {
		}
		if (Input.GetKey (KeyCode.W) && m_rb.transform.position.y <= 100) {
			m_rb.AddForce (Vector3.up * m_adjust * Time.deltaTime);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
		}
		if (!m_goForward && m_rb.velocity.z >= 0.01f) {
				m_rb.AddForce (Vector3.forward * m_slow * Time.deltaTime);
		}
		m_scoreText.text = "" + m_score;
		m_healthText.text = "" + m_health;
	}

	//collision checks
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Ring") {
			m_health--;
		}	
		if (other.gameObject.tag == "Asteroid") {
			m_health--; 
		}	
		if (other.gameObject.tag == "Ground") {
			m_health--; 
		}
	}
		
	//trigger checks
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Ring") {
			m_score += 500;
		}
		if (other.gameObject.tag == "End") {
			SceneManager.LoadSceneAsync ("Win_Screen");			
		}
	}

	//equations within class
}
