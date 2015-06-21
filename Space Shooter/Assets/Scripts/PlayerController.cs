using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	//these are accessible/changeable outside of this class
	public float speed;
	public Boundary boundary; //references created class
	public float tilt;  //tilt the ship on turn
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	//this is talking about what to update per frame.
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject
			GetComponent<AudioSource>().Play();
		}
	}

	//called auto by unity before each Fixed Physics Step
	void FixedUpdate()
	{
		//allows the player to move the player obj
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//x,y,z  <-- check your map to see moving in x and Z not y
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			 	0.0f , 
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			 );

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}