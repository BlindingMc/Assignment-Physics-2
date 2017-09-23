using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour {

	Text m_genericText;
	public string m_key;

	// Use this for initialization
	void Start () {
		m_genericText = GetComponent<Text> ();
		m_genericText.text = DataManager.LocalizeString (m_key);
	}
}
