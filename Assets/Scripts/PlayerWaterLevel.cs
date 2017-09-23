using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWaterLevel : MonoBehaviour {

	Rigidbody m_rb; 
	//forces
	float m_force;
	float m_jumpForce;
	float m_adjust;
	float m_slow;

	//canvas
	public Text m_scoreText;
	public Text m_speedText;


	//extra variables
	int m_score;
	bool m_goForward;
	bool m_scoreWait;


	float m_maxYBoundary;

	// Use this for initialization
	void Start () {
		m_rb = GetComponent <Rigidbody> ();
		m_force = 200.0f;
		m_jumpForce = 70.0f;
		m_adjust = 300.0f;
		m_slow = -10.0f;
		m_maxYBoundary = 15.0f;
		m_scoreWait = false;
		m_goForward = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (m_rb.position.y >= m_maxYBoundary) {
			m_rb.AddForce (Vector3.down * m_force);
		}


//		m_playerX = m_rb.transform.position.x;
//		m_playerY = m_rb.transform.position.y;


//		//brings player back within bounds of level
//		//max boundary to right of level
//		if (m_playerX >= m_maxXBoundary) {
//			m_rb.AddForce (Vector3.left * m_boundaryForceX);
//			m_pastMaxX = true;
//		} else {
//			m_pastMaxX = false;
//		}
//		//max boundary for left of level
//		if (m_playerX <= m_minXBoundary) {
//			m_rb.AddForce (Vector3.right * m_boundaryForceX);
//			m_pastMinX = true;
//		} else {
//			m_pastMinX = false;
//		}
//		//max boundary for bottom of level
//		//only if player is also out of X bounds, this is so player does not clip with ground
//		//past min X and min Y
//		if (m_playerY <= m_minYBoundary && m_playerX <= m_minXBoundary) {
//			m_rb.AddForce (Vector3.up * m_boundaryForceY);
//		} else if (m_playerY <= m_minYBoundary && m_playerX >= m_maxXBoundary) {
//			m_rb.AddForce (Vector3.up * m_boundaryForceY);
//		}

		//health.. win/ loss condition

		if (m_rb.position.z <= -192) {
			SceneManager.LoadSceneAsync ("Scenes/Menus & Other/Win_Screen");
		}

		//input
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (m_rb.velocity.z >= -5.9f) {
				m_rb.AddForce (Vector3.back * m_force * Time.deltaTime);
				m_goForward = true;
			}
		}


		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			m_goForward = false;
		}

		if (Input.GetKey (KeyCode.A)) {
			m_rb.AddForce (Vector3.right * m_adjust * Time.deltaTime);
			//			m_fireRight.Play ();
		}

		if (Input.GetKey (KeyCode.D)) {
			m_rb.AddForce (Vector3.left * m_adjust * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.W) && m_rb.position.y <= 0.9f) {
			m_rb.AddForce (Vector3.up * m_jumpForce);
		}

		if (!m_goForward && m_rb.velocity.z >= 0.01f) {
			m_rb.AddForce (Vector3.back * m_slow * Time.deltaTime);
		}

		if (m_rb.velocity.z >= -5.9f) {
			m_speedText.text = "" + m_rb.velocity.z * -2.5f;
		} else {
			m_speedText.text = "Maximum Power !!1!";
		}

		m_scoreText.text = "" + m_score;
	}

	//collision checks
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Boat" && !m_scoreWait) {
			m_score += 500;
			m_scoreWait = true;
			Invoke ("ScoreGrace", 0.7f);
		}
	}

	void ScoreGrace () {
		m_scoreWait = false;
	}
}