using UnityEngine;

/// <summary>
/// Contains all the code that relates to player, including movement and interact buttons.
/// </summary>
public class PlayerController : MonoBehaviour {

	#region Variables

	// Movement
	private Rigidbody2D rb;
	private Vector2 movement;
	[SerializeField] private float moveSpeed;

	private Camera mainCam;

	#endregion Variables

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
		mainCam = Camera.main;
	}

	// Start is called before the first frame update
	private void Start() {
		movement = Vector2.zero;
	}

	// Update is called once per frame
	private void Update() {
		CollectPlayerInputs();
	}

	private void FixedUpdate() {
		UpdatePlayerMovement();
	}

	private void LateUpdate() {
		UpdateCameraMovement();
	}

	/// <summary>
	/// Stores values for the direction and rotation player wants to move in
	/// </summary>
	private void CollectPlayerInputs() {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}

	/// <summary>
	/// Moves character dependent on inputs given by player
	/// </summary>
	private void UpdatePlayerMovement() {
		Vector2 moveDirection = new Vector2(movement.x, movement.y).normalized;
		rb.velocity = moveDirection * moveSpeed;

		// Rotates player in direction they are moving
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	/// <summary>
	/// Changes camera position so it always follows player
	/// </summary>
	private void UpdateCameraMovement() {
		mainCam.transform.position = new Vector2(transform.position.x, transform.position.y);
	}
}
