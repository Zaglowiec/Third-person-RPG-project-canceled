using UnityEngine;
using System.Collections;

public class YouDie : MonoBehaviour 
{
	GameOver gameOver;
	public GameObject BlackScreen;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void GameOver()
	{
		Time.timeScale = 0;
		
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		BlackScreen.GetComponent<GameOver> ().playerDie = true;
	}
}
