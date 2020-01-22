using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject startGameUI;
	public GameObject exitUI;
	public GameObject newGameUI;
	public GameObject helpMenu;

	// Use this for initialization
	void Start () 
	{
		mainMenuUI.SetActive (true);
		exitUI.SetActive (false);
		newGameUI.SetActive (false);
		helpMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartGamePressed()
	{
		mainMenuUI.SetActive (false);
		startGameUI.SetActive (true);
	}

	public void QuitGamePressed()
	{
		mainMenuUI.SetActive (false);
		exitUI.SetActive (true);
	}

	public void ContinuePressed()
	{
		Application.LoadLevel ("Level01");
	}

	public void NewGamePressed()
	{
		mainMenuUI.SetActive (false);
		newGameUI.SetActive (true);
	}

	public void QuitGameYesPressed()
	{
		//Wyjscie z gry i wylaczenie calej aplikacji
		Application.Quit ();
	}


	public void QuitGameNoPressed()
	{
		exitUI.SetActive (false);
		mainMenuUI.SetActive (true);
	}

	public void NewGameYesPressed()
	{
		//Przjescie do poczatku pierwszego poziomu
		Application.LoadLevel("Level01");
	}

	public void NewGameNoPressed()
	{
		newGameUI.SetActive (false);
		mainMenuUI.SetActive (true);
	}

	public void Help()
	{
		mainMenuUI.SetActive (false);
		helpMenu.SetActive (true);
	}

	public void BackHelp()
	{
		mainMenuUI.SetActive (true);
		helpMenu.SetActive (false);
	}

}
