using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed = 5;
	public float walkSideSpeed = 3;
	public float walkReverseSpeed = 2;
	public float rotateSpeed = 100;
	public float jumpStrength = 0.4f;
	
	Vector3 walkAcceleration = new Vector3(0,0,0);
	float jumpAcceleration = 0;
	
	int jumpCount = 0;
	
	public CharacterController playerController;
	public Animator playerAnimator;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		KeyboardInputs ();
		Movements ();
		
		//playerAnimator.SetFloat("walk", walkAcceleration.magnitude);
		//Debug.Log (walkAcceleration);
	}
	
	void KeyboardInputs()
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			if(playerController.isGrounded)
			{
				walkAcceleration += playerController.transform.forward * walkSideSpeed;
			}
			else
			{
				walkAcceleration = playerController.transform.forward * walkSideSpeed;
			}
		}
		
		if (Input.GetKey (KeyCode.W)) 
		{
			if(playerController.isGrounded)
			{
				walkAcceleration += playerController.transform.right * walkSpeed;
			}
			else
			{
				walkAcceleration = playerController.transform.right * walkSpeed;
			}
			
		}
		
		if (Input.GetKey(KeyCode.D))
		{
			
			if (playerController.isGrounded)
			{
				walkAcceleration += playerController.transform.forward * -walkSideSpeed;
			}
			else
			{
				walkAcceleration = playerController.transform.forward * -walkSideSpeed;
			}
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			
			if (playerController.isGrounded)
			{
				walkAcceleration += playerController.transform.right * -walkReverseSpeed;
			}
			else
			{
				walkAcceleration = playerController.transform.right * -walkReverseSpeed;
			}
		}

		//Jump

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if(jumpCount < 2)
			{
				jumpAcceleration = jumpStrength;
				jumpCount += 1;
			}
		}
		
		
	}
	
	void Movements()
	{
		
		playerAnimator.SetFloat("walk", walkAcceleration.magnitude);
		
		//Horizontal movements
		playerController.Move (walkAcceleration * Time.deltaTime);
		
		//Vertical movements
		playerController.Move (new Vector3 (0, jumpAcceleration, 0));
		
		//Rotation
		playerController.transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
		
		//Horizontal decelration
		if (playerController.isGrounded) 
		{
			walkAcceleration = Vector3.zero;
			jumpCount = 0;
		} 
		else 
		{
			walkAcceleration = Vector3.MoveTowards(walkAcceleration, Vector3.zero, Time.deltaTime);
		}
		
		if (jumpAcceleration > -0.98f) 
		{
			jumpAcceleration = Mathf.MoveTowards(jumpAcceleration, -0.98f, Time.deltaTime * 2);
		}
		
	}
	
	
	
}
