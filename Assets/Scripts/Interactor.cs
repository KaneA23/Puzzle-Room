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
	[SerializeField] private float interactRange = 2.0f;
	[SerializeField] private LayerMask validLayers;

	private Transform interactorSource;

	#endregion Variables

	// Start is called before the first frame update
	void Start() {
		interactorSource = transform;
	}

	// Update is called once per frame
	private void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			TryInteract();
		}
	}

	/// <summary>
	/// Checks with object player is looking at can be interacted with
	/// </summary>
	private void TryInteract() {
		RaycastHit2D hit = Physics2D.Raycast(interactorSource.position, Vector2.up, interactRange, validLayers);

		if (hit.collider != null) {
			if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
				interactObj.Interact();
			} else {
				Debug.LogError("Interactable object missing Interactable interface");
			}
		}
	}
}
