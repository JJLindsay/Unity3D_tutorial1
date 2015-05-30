using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed; //this can now be changed in the editor b/c it's public

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

}
