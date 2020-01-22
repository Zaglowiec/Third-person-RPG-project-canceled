using UnityEngine;
using System.Collections;

enum mode {mainMenu, quit}


public class PauseMenu : MonoBehaviour 
{

	public GameObject pauseMenuUI;
	public GameObject confirmUI;
	mode selectedMode;

	public bool next;

	// Use this for initialization
	void Start () 
	{
		pauseMenuUI.SetActive (false);
		confirmUI.SetActive (false);

		next = false;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !next) 
		{
			if (Time.timeScale == 1) 
			{
				Time.timeScale = 0;
				pauseMenuUI.SetActive (true);

				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else 
			{
				Time.timeScale = 1;
				pauseMenuUI.SetActive (false);

				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}


		if (Input.GetKeyDown (KeyCode.Escape) && next) 
		{
			if (Time.timeScale == 0) 
			{
				pauseMenuUI.SetActive (true);
				confirmUI.SetActive (false);

				next = false;
			}

		}
	}

	public void ContinueGamePressed()
	{
		Time.timeScale = 1;
		pauseMenuUI.SetActive (false);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void BackMainMenuPreesed()
	{
		selectedMode = mode.mainMenu;

		pauseMenuUI.SetActive (false);
		confirmUI.SetActive (true);
		next = true;
	}

	public void QiutGamePreese()
	{
		selectedMode = mode.quit;

		pauseMenuUI.SetActive (false);
		confirmUI.SetActive (true);
		next = true;
	}

	public void YesPressed()
	{
		if (selectedMode == mode.mainMenu) 
		{
			Application.LoadLevel ("MainMenu");
		} 
		else 
		{
			Application.Quit();
		}
	}

	public void NoPressed()
	{
		confirmUI.SetActive (false);
		pauseMenuUI.SetActive (true);
		next = false;
	}

}



