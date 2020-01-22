using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour 
{
	public float addHealtPoint = 0;
	public float addManaPoint = 0;
	public float addAttackDamage = 0;
	public float addSpecialAttackDamagr = 0;
	public float addDefense = 0;

	public GameObject particlePrefab;

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
			PlayerAttribute playerAttr = col.gameObject.GetComponent<PlayerAttribute> ();
			playerAttr.manaPoint += addManaPoint;
			playerAttr.health += addHealtPoint;
			playerAttr.attackDamage += addAttackDamage;
			playerAttr.specialAttackDamage += addSpecialAttackDamagr;
			playerAttr.defense += addDefense;

			Instantiate (particlePrefab, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}

}
