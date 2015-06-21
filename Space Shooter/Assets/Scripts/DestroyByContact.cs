using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion; 
	public GameObject playerExplosion;

	public int scoreValue;
	private GameController gameController; //this is being set not by us in the inspector but in game.

	void Start()
	{
		//on start find an instance of GameController
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) //this is just an insurance policy of sorts should game controller
			//NOT gameControllerObject come out null
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

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
			//scoreValue += 1;
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);  //destroys the object this script is attached to
	}
}
