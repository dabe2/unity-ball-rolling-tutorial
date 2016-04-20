using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		setCountText();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText();

			if (count >= 12) {
				winText.text = "YOU WIN!";	
			}
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString ();
	}
}
