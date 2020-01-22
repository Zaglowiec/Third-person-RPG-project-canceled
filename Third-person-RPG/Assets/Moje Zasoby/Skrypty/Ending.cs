using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ending : MonoBehaviour 
{

	public Image blackScreen;
	Color blackScreenColor;
	public float lerpMulitpler = 0.001f;
	
	public bool BossDie;
	
	public Text text;
	Color colorText;

	
	// Use this for initialization
	void Start () 
	{
		blackScreenColor = new Color (0, 0, 0, 0);
		blackScreen.color = blackScreenColor;
		
		colorText = new Color (1, 1, 1, 0);
		text.color = colorText;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BossDie == true)
		{
			//Time.timeScale = 0;

			blackScreenColor = Color.Lerp (blackScreenColor, new Color (0, 0, 0, 1), Time.time * lerpMulitpler);
			blackScreen.color = blackScreenColor;
			
			colorText = Color.Lerp (colorText, new Color (1, 1, 1, 1), Time.time * lerpMulitpler);
			text.color = colorText;

			StartCoroutine(End());
		}
	}

	IEnumerator End()
	{
		yield return new WaitForSeconds (10);

		Application.LoadLevel ("MainMenu");
	}
}
