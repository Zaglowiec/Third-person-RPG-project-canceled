using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

	public Image logo;
	Color logoColor;
	public float lerpMulitpler = 0.02f;

	// Use this for initialization
	void Start () 
	{
		logoColor = new Color (1, 1, 1, 0);
		logo.color = logoColor;

		StartCoroutine (GotoMainMenu());
	}
	
	// Update is called once per frame
	void Update () 
	{
		logoColor = Color.Lerp (logoColor, new Color (1, 1, 1, 1), Time.time * lerpMulitpler);
		logo.color = logoColor;
	}

	IEnumerator GotoMainMenu()
	{
		yield return new WaitForSeconds (4);
		Debug.Log("Next Scene");
		Application.LoadLevel("MainMenu");
	}

}
