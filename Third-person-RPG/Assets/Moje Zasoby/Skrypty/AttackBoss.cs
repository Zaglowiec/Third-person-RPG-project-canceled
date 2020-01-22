using UnityEngine;
using System.Collections;

public class AttackBoss : MonoBehaviour 
{

	public Boss boss;
	public PlayerAttribute playerAttribute;
	
	GameObject player;
	public GameObject EnemyBoss;
	
	public Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void PlayerDamage()
	{
		Debug.Log("Działa");
		
		if(EnemyBoss.GetComponent<Boss>().attack == true)
		{
			player.GetComponent<PlayerAttribute>().getDamagePlayer(EnemyBoss.GetComponent<Boss>().damage);
			
		}
		
	}
}
