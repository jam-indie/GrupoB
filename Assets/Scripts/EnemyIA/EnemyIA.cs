using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour 
{
	public Transform player;
	private float vel;
	// Use this for initialization
	void Start () 
	{
		vel = 0.1f;	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (player.position, transform.position) < 15) 
		{
			transform.position = Vector3.Slerp(transform.position, player.transform.position, vel*Time.deltaTime);
		}
		if (Vector3.Distance (player.position, transform.position) < 5) 
		{
			vel = 0;
		}
		if (Vector3.Distance (player.position, transform.position) > 5) 
		{
			vel = 0.1f;
		}
	}
}
