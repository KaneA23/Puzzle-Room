using UnityEngine;

/// <summary>
/// Creates an inheritted Interact button for all interactable objects
/// </summary>
interface IInteractable {
	public void Interact();
}

/// <summary>
/// Contains code to allow the player to interact with objects infront of them
/// </summary>
public class Interactor : MonoBehaviour {

	#region Variables

	[Header("Interactable Settings")]
	[SerializeField] private Transform interactorSource;
	[SerializeField] private float interactRange = 2.0f;
	[SerializeField] private LayerMask validLayers;

	[Space(5)]
	[SerializeField] private GameObject interactPrompt;

	private bool isHit;

	#endregion Variables

	#region Unity Methods

	// Start is called before the first frame update
	void Start() {
		interactPrompt.SetActive(false);
	}

	// Update is called once per frame
	private void Update() {
		CheckForInteractions();
	}

	#endregion Unity Methods

	/// <summary>
	/// Check for interactable objects in the player's line of sight
	/// </summary>
	private void CheckForInteractions() {
		RaycastHit2D hit = Physics2D.Raycast(interactorSource.position, interactorSource.up, interactRange, validLayers);
		isHit = hit.collider != null;
		interactPrompt.SetActive(isHit);

		if (isHit) {
			if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
				if (Input.GetKeyDown(KeyCode.E)) {
					interactObj.Interact();
				}
			} else {
				Debug.LogError("Interactable object missing Interactable interface");
			}
		}
	}
}
