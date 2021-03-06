﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;	
	}
	
	// Update is called once per frame but guaranteed to run after ALL items
	//have been processed in update.
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
	}
}