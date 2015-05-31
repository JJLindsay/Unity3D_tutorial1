using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
	{
		//rotates the object independently of the frames.
		//notice this uses NEW vector3 which is different from the api page ctrl+' for rotate
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
