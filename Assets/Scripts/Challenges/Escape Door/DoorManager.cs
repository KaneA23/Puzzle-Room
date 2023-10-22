using UnityEngine;

public class DoorManager : MonoBehaviour, IInteractable {

	#region Variables

	[SerializeField] private string correctPasscode = "1234";

	[SerializeField] private GameObject passcodeUI;

	#endregion Variables

	#region Unity Methods

	// Start is called before the first frame update
	void Start() {
		passcodeUI.SetActive(false);
	}

	// Update is called once per frame
	void Update() {

	}

	#endregion Unity Methods

	public void Interact() {
		passcodeUI.SetActive(true);
		Time.timeScale = 0.0f;
	}

	public void ValidatePasscode(string a_enteredPasscode) {
		Debug.Log("Checking");
		if (correctPasscode == a_enteredPasscode) {
			Debug.Log("Correct!");

			passcodeUI.SetActive(false);
			Time.timeScale = 1.0f;

			Destroy(gameObject);
		}
	}
}
