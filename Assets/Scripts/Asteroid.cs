using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	Rigidbody m_rb;

	public string key;
	private AsteroidData data;

	// Use this for initialization
	void Start () {
		data = DataManager.GetAsteroidData (key);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.left * data.Rotation * Time.deltaTime);
		transform.Rotate (Vector3.up * data.Rotation2 * Time.deltaTime);
		transform.Translate (Vector3.right * data.Speed * Time.deltaTime);
	}
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	} 
}