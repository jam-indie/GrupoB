using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour 
{
	//public GameObject Player;
	//public Transform FollowTranform;
	private float vel;

	//OnGuard void variables
	public Vector2 MyStartPosition;
	public Vector2 DistanceToGuardA;
	public Vector2 DistanceToGuardB;
	
	public float Perimetro;

	public bool TestePerimetro;
	void Start () 
	{
		//Player = GameObject.Find("Player");
		//FollowTranform = Player.transform;
		MyStartPosition = gameObject.transform.position;
		DistanceToGuardA = new Vector2(5,-3);
		DistanceToGuardB = new Vector2(-5,-3);
		vel = 1;
		TestePerimetro = true;
	}
	
	void Update () 
	{
		MountGuard ();
	}

	void MountGuard()//This void makes the gameObject set up a perimeter to keep it
	{
		Perimetro = Vector2.Distance (transform.position, DistanceToGuardA);

		if (TestePerimetro) 
		{
			transform.position = Vector2.MoveTowards (transform.position, DistanceToGuardA, vel * Time.deltaTime);
		}
	}

	void DetectPlayer()//Here you setup the Raycast, and test if the player collides on him
	{
		/*if (Vector3.Distance (FollowTranform.position, transform.position) < 15) 
		{
			transform.position = Vector3.Slerp(transform.position, FollowTranform.position, vel*Time.deltaTime);
		}
		if (Vector3.Distance (FollowTranform.position, transform.position) < 1) 
		{
			vel = 0;
		}
		if (Vector3.Distance (FollowTranform.position, transform.position) > 5) 
		{
			vel = 0.1f;
		}*/
	}

	void OnAlert()//This void makes the gameObject look for the player in the last place he saw
	{
		/*
		 *	Initially , you need to get the latest position where the player was , this is the challenge ! because I do not know how we do that too : D but with Raycast , you can detect when an object out of it , is a tip.
		 *	Now, with this information, you will call the Void MountGuard and set the StartPerimeter with this information.
		 *	Use a AlertCounter (chosen by the developer ) when he finished, the gameObject returns to its original perimeter.
		 *	
		 *	When you finish the above logic , you can do the following gameObject to random positions in its alert Perimeter , and then go to such positions.
		 */
	}
}
