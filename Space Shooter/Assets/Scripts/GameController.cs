using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	//this can be set in the inspector since its public.
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//score
	public GUIText scoreText;
	private int score;

	//gameOver/restart
	public GUIText gameOverText;
	public GUIText restartText;
	
	private bool gameover;
	private bool restart;

	//this is called automatically on startup in Unity3D
	void Start()
	{
		restart = false;
		gameover = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				//loads the level or scene file specified in the parentheses
				Application.LoadLevel(Application.loadedLevel); //loadedLevel is the currenly loaded level
			}
		}
	}

	//creates objects
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);  //a brief pause before the wave begins
		while(true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				//Use scene or game to figure out these points/ranges. Y & Z are fixed
				//but x is random.
				//new Vector3 ();
				//Random.Range(-6.6F, 6.2F)
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;  //set the spaw rotation. Identity equals no rotation

				//create this object with this location and rotation
				Instantiate (hazard, spawnPosition, spawnRotation);

				//This is timer in Java
				yield return new WaitForSeconds(spawnWait);  //a delay between each asteroid

				if (gameover)
				{
					restartText.text = "Press 'R' to Restart";
					restart = true;
					break;
				}
			}
			//This is timer in java
			yield return new WaitForSeconds(waveWait);

			if (gameover)
			{
				//restartText.text = "Press 'R' to Restart";
				//restart = true;
				//break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameover = true;
	}
}
