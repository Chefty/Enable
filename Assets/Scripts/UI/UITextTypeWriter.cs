using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextTypeWriter : MonoBehaviour
{
	public string story;
	private TextMeshProUGUI txt;
	
	void Awake() {
		txt = GetComponent<TextMeshProUGUI>();
		CallClearAndPlayText();
	}

	public void CallClearAndPlayText() {
		StartCoroutine(ClearAndPlayTextCO());
	}

	public IEnumerator ClearAndPlayTextCO() {
		txt.text = "";
		foreach (char c in story) {
			txt.text += c;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
