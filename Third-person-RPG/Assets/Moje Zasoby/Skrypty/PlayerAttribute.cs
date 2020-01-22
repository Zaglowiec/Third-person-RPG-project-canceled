using UnityEngine;
using System.Collections;

public class PlayerAttribute : MonoBehaviour 
{
	public int level = 1;
	public float healthPoint = 100;
	public float manaPoint = 0;
	public float attackDamage = 10;
	public float specialAttackDamage = 50;
	public float defense = 2;

	//private
	public float health;
	public Animator anim;
	bool death;

	YouDie youDie;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		health = healthPoint;
		death = false;

		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void getDamagePlayer(float damage)
	{
		health -= damage;

		if (health <= 0) 
		{
			Debug.Log ("Umierammm...");
			death = true;
			StartCoroutine (Die());
		}
	}


	IEnumerator Die()
	{
		anim.SetBool ("death", death);
		GetComponent<BoxCollider> ().isTrigger = true;
		
		yield return new WaitForSeconds(2);

		player.GetComponent<YouDie> ().GameOver ();
	}
}
