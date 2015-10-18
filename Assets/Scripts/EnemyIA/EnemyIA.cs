using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour 
{
	public GameObject Player;
	public Transform FollowTRanform;
	private float vel;

	//OnGuard void variables
	public Vector3 MyStartPosition;
	public float DistanceToGuard;

	void Start () 
	{
		Player = GameObject.Find("Player");
		FollowTRanform = Player.transform;
		vel = 0.1f;
		MyStartPosition = gameObject.transform.position;
	}
	
	void Update () 
	{
		//Please clean the update void and setup the below voids 
		if (Vector3.Distance (FollowTRanform.position, transform.position) < 15) 
		{
			transform.position = Vector3.Slerp(transform.position, FollowTRanform.position, vel*Time.deltaTime);
		}
		if (Vector3.Distance (FollowTRanform.position, transform.position) < 1) 
		{
			vel = 0;
		}
		if (Vector3.Distance (FollowTRanform.position, transform.position) > 5) 
		{
			vel = 0.1f;
		}
	}

	void MountGuard(Vector3 StartPerimeter)//This void makes the gameObject set up a perimeter to keep it
	{
		/*
		 *	This gameobject will choose a starting position.
		 *	The perimeter of this gameObject guard equals MyStartPosition + DistanceToGuard (Distance to the developer chooses ) .
		 *	MyStartPosition + DistanceToGuard = the value of the position in which this gameObject will stop, the perimeter edge he keeps .
		 *	When this gameObject reach the limit of its perimeter , it will stop for a random time .
		 *	When this random time is up, he will go to the other end of its perimeter .
		 *	When this GameObject reach the other end , you will stop for a random time and will be in there.
		 *	So we have a loop where it goes back and forth from one end to another of the perimeter .
		 *	
		 *	When this logic is done, you can do a little more, make this gamObject randomly stop at some random point the way to the end , for a random time , and after this time is up, he chooses a new direction to go.
		 */
	}

	void DetectPlayer()//Here you setup the Raycast, and test if the player collides on him
	{
		//Please, use vector3.Lerp to make this gameObject follow the player.
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
