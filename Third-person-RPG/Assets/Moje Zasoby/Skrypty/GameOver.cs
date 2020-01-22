using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	public Image blackScreen;
	Color blackScreenColor;
	public float lerpMulitpler = 0.001f;

	public bool playerDie;

	public Text text;
	Color colorText;

	public GameObject Button;

	// Use this for initialization
	void Start () 
	{
		playerDie = false;
		Button.SetActive(false);

		blackScreenColor = new Color (0, 0, 0, 0);
		blackScreen.color = blackScreenColor;

		colorText = new Color (1, 1, 1, 0);
		text.color = colorText;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerDie == true)
		{
			blackScreenColor = Color.Lerp (blackScreenColor, new Color (0, 0, 0, 1), Time.time * lerpMulitpler);
			blackScreen.color = blackScreenColor;

			colorText = Color.Lerp (colorText, new Color (1, 1, 1, 1), Time.time * lerpMulitpler);
			text.color = colorText;

			Button.SetActive(true);
		}
	}

	
	public void Menu()
	{
		Application.LoadLevel ("MainMenu");
	}
	
	public void QuitGame()
	{
		Application.Quit ();
	}
	
	public void NewGame()
	{
		Application.LoadLevel("Level01");
	}


}
