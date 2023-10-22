using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTable : MonoBehaviour, IInteractable {

	#region Variables

	[SerializeField] private GameObject introUI;

	#endregion Variables

	#region Unity Methods

	// Start is called before the first frame update
	void Start() {
		introUI.SetActive(false);
	}

	// Update is called once per frame
	void Update() {

	}

	#endregion Unity Methods

	public void Interact() {
		introUI.SetActive(true);
		Time.timeScale = 0.0f;
	}
}
