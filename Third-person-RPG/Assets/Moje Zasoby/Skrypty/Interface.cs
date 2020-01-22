using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour 
{
	public Text healthPlayer;
	public Text manaPlayer;
	PlayerAttribute playerAttribute;
	GameObject player;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.GetComponent<PlayerAttribute> ().health < 0)
			player.GetComponent<PlayerAttribute> ().health = 0;

		if (player.GetComponent<PlayerAttribute> ().manaPoint < 0)
			player.GetComponent<PlayerAttribute> ().manaPoint = 0;

		healthPlayer.text = "" + player.GetComponent<PlayerAttribute> ().health;
		manaPlayer.text = "" + player.GetComponent<PlayerAttribute> ().manaPoint;
	}
}
