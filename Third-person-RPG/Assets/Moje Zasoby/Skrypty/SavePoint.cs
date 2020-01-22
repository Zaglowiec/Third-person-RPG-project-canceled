using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour 
{
	public SaveManager saveManager;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") 
		{
			saveManager.ShowSaveDialogUI();
		}
	}
	

}
