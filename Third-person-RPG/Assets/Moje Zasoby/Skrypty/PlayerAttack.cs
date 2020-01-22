using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{

	//public float attackDamage = 10;
	public float attackCooldownTimeInterval = 8;
	float attackCooldownTime = 0;

	ArrayList nearbyEnemy;
	public PlayerAttribute playerAttribute;

	public GameObject bulletPrefab;

	public Animator anim;
	public bool attack;

	Boss boss;
	bool nearbyBoss;
	public GameObject EnemyBoss;

	// Use this for initialization
	void Start () 
	{
		nearbyEnemy = new ArrayList ();
		attack = false;

		nearbyBoss = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetButtonDown("Fire1")) 
		{
			//Debug.Log("Klik");

			if(Time.time > attackCooldownTime && !attack)
			{
				attack = true;
				//Debug.Log("Mogę?");
				anim.SetBool("attack", attack);

				if(nearbyEnemy.Count > 0)
				{
					//Debug.Log("Coś jest");
					//Zadaj obrażenia wszystkim pobliskim wrogom
					for(int  i = 0; i< nearbyEnemy.Count; i++)
					{
						(nearbyEnemy[i] as GameObject).GetComponent<EnemyAI>().GetDamage(playerAttribute.attackDamage);
						Debug.Log("Giń");
					}
				}

				if(nearbyBoss == true)
				{
					EnemyBoss.GetComponent<Boss>().GetDamage(playerAttribute.attackDamage);
				}

				attackCooldownTime = Time.time + attackCooldownTimeInterval;
			}
		}

		//Specjal Attack
		/*
		if (Input.GetButtonDown ("Fire2")) 
		{
			if (playerAttribute.manaPoint >= 100) 
			{
				for (int i = 0; i < 8; ++i) 
				{
					Instantiate (bulletPrefab, transform.position + new Vector3 (0, 0, 0), transform.rotation * Quaternion.Euler (new Vector3 (0, 45 * i, 0)));
				}
				
				playerAttribute.manaPoint -= 100;
			}
		}*/
	}

	void OnTriggerEnter (Collider col)
	{
		//Dodaj pobliskiego wroga do tablicy, jeśli jesteś w zasięgu ataku
		if (col.tag == "Monster") 
		{
			nearbyEnemy.Add (col.gameObject);
		}

		if (col.tag == "Boss") 
		{
			nearbyBoss = true;
		}
	}



	void OnTriggerExit (Collider col)
	{
		//Usuń wroga z tablicy, jeśli nie jesteś w zasięgu ataku
		if (col.tag == "Monster") 
		{
			for(int i = 0; i < nearbyEnemy.Count; i++)
			{
				if(nearbyEnemy[i] == col.gameObject)
				{
					nearbyEnemy.RemoveAt(i);
				}
			}
		}

		if (col.tag == "Boss") 
		{
			nearbyBoss = false;
		}
	}

	public void StopAttack()
	{
		attack = false;
		anim.SetBool("attack", attack);
	}
}
