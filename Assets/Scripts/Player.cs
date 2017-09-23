using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	Rigidbody m_rb; 
	//forces

	//canvas
	public Text m_scoreText;
	public Text m_speedText;
	public Text m_healthText;

	//extra variables
	int m_score;
	bool m_goForward;
	int m_health = 3;
	bool m_damageGrace;

	//boundary variables
	public float m_playerX;
	public float m_playerY;
	public bool m_pastMinX;
	public bool m_pastMaxX;

	// Use this for initialization
	void Start () {
		m_rb = GetComponent <Rigidbody> ();
		m_goForward = false;
		m_damageGrace = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		m_playerX = m_rb.transform.position.x;
		m_playerY = m_rb.transform.position.y;


		//brings player back within bounds of level
		//max boundary to right of level
		if (m_playerX >= DataManager.GetConstant<float> ("BoundaryMaxX")) {
			m_rb.AddForce (Vector3.left * DataManager.GetConstant<float> ("BoundaryForceX"));
			m_pastMaxX = true;
		} else {
			m_pastMaxX = false;
		}
		//max boundary for left of level
		if (m_playerX <= DataManager.GetConstant<float> ("BoundaryMinX")) {
			m_rb.AddForce (Vector3.right * DataManager.GetConstant<float> ("BoundaryForceX"));
			m_pastMinX = true;
		} else {
			m_pastMinX = false;
		}
		//max boundary for bottom of level
		//only if player is also out of X bounds, this is so player does not clip with ground
		//past min X and min Y
		if (m_playerY <= DataManager.GetConstant<float> ("BoundaryMinY") && m_playerX <= DataManager.GetConstant<float> ("BoundaryMinX")) {
			m_rb.AddForce (Vector3.up * DataManager.GetConstant<float> ("BoundaryForceY"));
		} else if (m_playerY <= DataManager.GetConstant<float> ("BoundaryMinY")&& m_playerX >= DataManager.GetConstant<float> ("BoundaryMaxX")) {
			m_rb.AddForce (Vector3.up * DataManager.GetConstant<float> ("BoundaryForceY"));
		}

		//health.. win/ loss condition
		if (m_health == 0) {
			SceneManager.LoadSceneAsync ("Game_Over");
		}

		//input
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (m_rb.velocity.z <= 15) {
				m_rb.AddForce (Vector3.forward * DataManager.GetConstant<float> ("Speed") * Time.deltaTime);
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

		if (Input.GetKey (KeyCode.A) && !m_pastMinX) {
			m_rb.AddForce (Vector3.left * DataManager.GetConstant<float> ("Adjust") * Time.deltaTime);
//			m_fireRight.Play ();
		}

		if (Input.GetKey (KeyCode.D) && !m_pastMaxX) {
			m_rb.AddForce (Vector3.right * DataManager.GetConstant<float> ("Adjust") * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.W) && m_rb.transform.position.y <= 55) {
			m_rb.AddForce (Vector3.up * DataManager.GetConstant<float> ("Adjust") * Time.deltaTime);
		}
	
		if (!m_goForward && m_rb.velocity.z >= 0.01f) {
			m_rb.AddForce (Vector3.forward * DataManager.GetConstant<float> ("Slow") * Time.deltaTime);
		}

		m_scoreText.text = "" + m_score;
		m_healthText.text = "" + m_health;
	}

	//collision checks
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Ring" && !m_damageGrace) {
			m_health--;
			m_damageGrace = true;
			Invoke ("DamageGrace", 1.5f);
		}	
		if (other.gameObject.tag == "Asteroid") {
			m_health--; 
		}	
		if (other.gameObject.tag == "Ground" && !m_damageGrace) {
			m_health--; 
			m_damageGrace = true;
			Invoke ("DamageGrace", 1.5f);
		}
	}
		
	//trigger checks
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Ring") {
			m_score += 500;
		}
		if (other.gameObject.tag == "End") {
			SceneManager.LoadSceneAsync ("Cinematic_1");			
		}
	}

	//turning damage grace off 
	void DamageGrace () {
		m_damageGrace = false;
	}

}
