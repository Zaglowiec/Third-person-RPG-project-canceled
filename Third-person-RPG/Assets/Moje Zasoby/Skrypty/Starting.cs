using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Starting : MonoBehaviour {

	public Image start;
	Color startColor;
	public float lerpMulitpler = 0.02f;

	public Text text;
	Color colorText;

	bool startGame;
	
	// Use this for initialization
	void Start () 
	{

		startColor = new Color (0, 0, 0, 1);
		start.color = startColor;

		colorText = new Color (1, 1, 1, 1);
		text.color = colorText;

		StartCoroutine (GotoGame());

		startGame = false;

		Time.timeScale = 0;		
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startGame == true) 
		{
			startColor = Color.Lerp (startColor, new Color (0, 0, 0, 0), Time.time * lerpMulitpler);
			start.color = startColor;

			colorText = Color.Lerp (colorText, new Color (1, 1, 1, 0), Time.time * lerpMulitpler);
			text.color = colorText;
		}
	}
	
	IEnumerator GotoGame()
	{
		yield return new WaitForSeconds (10);

		startGame = true;

		yield return new WaitForSeconds (5);

		Destroy (gameObject);
	}
}
