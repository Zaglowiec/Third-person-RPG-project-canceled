using UnityEngine;
using System.Collections;

public class AttackMonster : MonoBehaviour 
{
	public EnemyAI enemyAI;
	public PlayerAttribute playerAttribute;

	GameObject player;
	public GameObject enemy;

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

		if(enemy.GetComponent<EnemyAI>().attack == true)
		{
			player.GetComponent<PlayerAttribute>().getDamagePlayer(enemy.GetComponent<EnemyAI>().damage);

		}

	}

}
