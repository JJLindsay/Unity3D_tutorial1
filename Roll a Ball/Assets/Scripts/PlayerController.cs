using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	//public variables
	public float speed; //this can now be changed in the editor b/c it's public
	public Text countText;
	public Text winText;

	//private variables
	private Rigidbody rb;
	private int count; //for the score

	void Start()
	{
		//sets up the Unity rigid body physics which effects collions and adds gravity
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	void FixedUpdate()
	{
		//can the player move left and right, up and down
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//movement will be processed in the x and y coordinates only, not z
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//added force to the movement will be set manually in the player component under script 
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		//if we collide into one of our pick ups with the tag pick up 
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}

		if (count == 12) 
		{
			winText.text = "You Win!";
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}