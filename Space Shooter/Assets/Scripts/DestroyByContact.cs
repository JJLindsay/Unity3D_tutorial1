using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion; 
	public GameObject playerExplosion;

	//upon entering, destroy the object of the other gameobject
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("The name of the other object impacting the asteroid is: " + other.name);  //help find out why the asteroid vanishes on start
		//destroy happens at the end of the frame so the order here doesn't matter.
		if (other.tag == "Boundary") 
		{
			return;
		} 
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);  //destroys the object this script is attached to
	}
}
