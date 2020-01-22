using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Boss : MonoBehaviour 
{
	public NavMeshAgent agent;
	public float healthPoint = 50;
	public Animator animator;
	GameObject player;
	public float damage = 5;
	
	Vector3 randomPos;
	float pauseInterval = 0;
	float pauseTime = 0;
	
	public bool attack;
	
	bool death;
	
	PlayerAttribute playerAttribute;

	Ending ending;
	public GameObject end;
	
	// Use this for initialization
	void Start () 
	{
		//Znajdź gracza
		player = GameObject.FindWithTag ("Player");
		CalculateRandomPosition ();
		
		attack = false;
		death = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(player != null && !death && !attack)
		{
			// Sprawdź, czy gracz jest w pobliżu
			if(Vector3.Distance(transform.position, player.transform.position) <= 10)
			{
				//Idź do gracza
				agent.SetDestination(player.transform.position);
				//Wysli prędkośc ruchu do animatora potwora
				animator.SetFloat("WalkP", agent.velocity.magnitude);
			}
			else
			{
				if(Vector3.Distance(transform.position, randomPos) < 3)
				{
					CalculateRandomPosition();
					pauseInterval = Random.Range (2, 10);
					pauseTime = Time.time + pauseInterval;
				}
				else
				{
					if(pauseTime < Time.time)
					{
						agent.SetDestination(randomPos);
						
						if(agent.velocity == Vector3.zero)
						{
							CalculateRandomPosition();
						}
					}
				}
			}
		}
		
	}
	
	public void GetDamage(float damage)
	{
		healthPoint -= damage;
		Debug.Log("Auuuł");
		
		if (healthPoint <= 0) 
		{
			death = true;
			StartCoroutine (Die());
		}
		
	}
	
	
	IEnumerator Die()
	{
		animator.SetBool ("DeathP", death);
		GetComponent<BoxCollider> ().isTrigger = true;

		end.GetComponent<Ending>().BossDie = true;

		yield return new WaitForSeconds(5);
		
		GetComponent<NavMeshAgent> ().enabled = false;
		yield return new WaitForSeconds(1);
		
		Destroy (gameObject);
	}
	
	void CalculateRandomPosition()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition (transform.position + Random.insideUnitSphere * Random.Range (3, 10), out hit, 10, NavMesh.AllAreas);
		
		randomPos = hit.position;
	}
	
	
	void OnTriggerEnter (Collider col)
	{
		//Dodaj pobliskiego wroga do tablicy, jeśli jesteś w zasięgu ataku
		if (col.tag == "Player") 
		{
			attack = true;
			
			animator.SetBool("AttackP", attack);
		}
	}
	
	
	
	void OnTriggerExit (Collider col)
	{
		//Usuń wroga z tablicy, jeśli nie jesteś w zasięgu ataku
		if (col.tag == "Player") 
		{
			attack = false;
		}
	}
	/*
	public void setPlayerDamage()
	{
		if (attack == true) 
		{
			GetComponent<PlayerAttribute>().getDamagePlayer(damage);
		}
	}
	*/
}
