using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	//this can be set in the inspector since its public.
	public GameObject hazard;
	public Vector3 spawnValues;

	//this is called automatically on startup in Unity3D
	void Start()
	{
		SpawnWaves ();
	}

	//creates objects
	void SpawnWaves()
	{
		//Use scene or game to figure out these points/ranges. Y & Z are fixed
		//but x is random.
		//new Vector3 ();
		//Random.Range(-6.6F, 6.2F)
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;  //set the spaw rotation. Identity equals no rotation

		//create this object with this location and rotation
			Instantiate (hazard, spawnPosition, spawnRotation);
	}
}
