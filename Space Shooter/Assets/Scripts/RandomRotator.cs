using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;

	// Use this for initialization
	void Start () 
	{
		//randomizes each directon of a sphere to simulate ratational direction
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
