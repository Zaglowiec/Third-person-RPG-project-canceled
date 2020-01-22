using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour 
{

	//ArrayList nearbyEnemy;
	public PlayerAttribute playerAttribute;
	

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DestroyBullet ());
		//nearbyEnemy = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * Time.deltaTime * 5;
		/*
		if(nearbyEnemy.Count > 0)
		{
			//Zadaj obrażenia wszystkim pobliskim wrogom
			for(int  i = 0; i< nearbyEnemy.Count; i++)
			{
				(nearbyEnemy[i] as GameObject).GetComponent<EnemyAI>().GetDamage(playerAttribute.attackDamage);
			}
		}*/
	}

	IEnumerator DestroyBullet ()
	{
		yield return new WaitForSeconds(5);

		//nearbyEnemy.Clear();

		Destroy(gameObject);
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Monster") 
		{
			col.GetComponent<EnemyAI>().GetDamage(playerAttribute.specialAttackDamage);
		}
	}

	/*
	void OnTriggerEnter (Collider col)
	{
		//Dodaj pobliskiego wroga do tablicy, jeśli jesteś w zasięgu ataku
		if (col.tag == "Monster") 
		{
			nearbyEnemy.Add (col.gameObject);
		}
	}
	*/

}
