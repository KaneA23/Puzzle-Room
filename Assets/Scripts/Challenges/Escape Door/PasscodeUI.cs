using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasscodeUI : MonoBehaviour {
	private TMP_InputField passcodeInputField;

	private void Awake() {
		passcodeInputField = GetComponentInChildren<TMP_InputField>();
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private void OnEnable() {
		if (passcodeInputField && passcodeInputField.IsActive() && passcodeInputField.IsInteractable()) {
			passcodeInputField.Select();
			passcodeInputField.ActivateInputField();
		}
	}
}
