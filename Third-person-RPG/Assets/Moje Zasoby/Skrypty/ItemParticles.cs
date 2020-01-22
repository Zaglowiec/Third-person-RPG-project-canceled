using UnityEngine;
using System.Collections;

public class ItemParticles : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DestroyParticles ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator DestroyParticles()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
