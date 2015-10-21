using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewEnemyIA : MonoBehaviour 
{
	public GameObject Player;

	public float Vel;
	public float GuardPerimeter;

	public Vector2 WhereToGo;
	public Vector2 StartPosition;

	public List<Vector2> GuardEdges;
	public List<bool> MovingTo; 

	public float GuardCount;

	public float AlertTime;

	private float StartAlertTime;

	private float StartGuardCount;

	private RaycastHit2D hit;

	private Vector2 LastPlayerPos;

	private bool StartToCountDown;

	public bool LookingForPlayer;

	void Start () 
	{
		StartPosition = gameObject.transform.position;

		StartAlertTime = AlertTime;
		StartGuardCount = GuardCount;

		MovingTo [0] = true; 
		StartToCountDown = false;

		MountGuard (StartPosition);
	}
	
	void Update () 
	{
		Player = GameObject.Find ("Player");
		gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position,WhereToGo, Vel * Time.deltaTime);
		DetectPlayer ();

		if(LookingForPlayer == false)
		{
			MountGuard(StartPosition);
		}
	}

	void MountGuard(Vector2 CenterPosition)
	{
		GuardEdges [0] = new Vector2 (CenterPosition.x + GuardPerimeter, gameObject.transform.position.y);
		GuardEdges [1] = new Vector2 (CenterPosition.x - GuardPerimeter, gameObject.transform.position.y);

		if(gameObject.transform.position.x == GuardEdges[0].x)
		{
			GuardCount -= Time.deltaTime;
			if(GuardCount < 0)
			{
				GuardCount = StartGuardCount;
				MovingTo[0] = false;
				MovingTo[1] = true;
			}
		}
		if(gameObject.transform.position.x == GuardEdges[1].x)
		{
			GuardCount -= Time.deltaTime;
			if(GuardCount < 0)
			{
				GuardCount = StartGuardCount;
				MovingTo[0] = true;
				MovingTo[1] = false;
			}
		}

		if(MovingTo[0] == true)
		{
			WhereToGo = GuardEdges[0];
			gameObject.transform.localScale = new Vector3(1,1,1);
		}
		if(MovingTo[1] == true)
		{
			WhereToGo = GuardEdges[1];
			gameObject.transform.localScale = new Vector3(-1,1,1);
		}
	}

	void DetectPlayer()//Here you setup the Raycast, and test if the player collides on him
	{
		hit = Physics2D.Raycast (transform.position, Vector2.right * gameObject.transform.localScale.x, 8);
		Debug.DrawRay (transform.position, Vector2.right * gameObject.transform.localScale.x * 8, Color.red);
		
		if(hit.collider != null)//I use this if to stop de console error: NullReferenceException: Object reference not set to an instance of an object
		{
			if(hit.collider.gameObject == Player)
			{
				LastPlayerPos = hit.point;
				WhereToGo = LastPlayerPos;
				MovingTo[0] = false;
				MovingTo[1] = false;
				LookingForPlayer = true;
			}
		}

		OnAlertAndFollow ();
	}

	void OnAlertAndFollow()//This void makes the gameObject look for the player in the last place he saw
	{
		MountGuard (LastPlayerPos);

		if(LastPlayerPos.x != 0 && gameObject.transform.position.x == LastPlayerPos.x)
		{
			if(gameObject.transform.localScale.x == 1)
			{
				MovingTo[0] = true;
				MovingTo[1] = false;
			}
			if(gameObject.transform.localScale.x == -1)
			{
				MovingTo[0] = false;
				MovingTo[1] = true;
			}
		}

		if(gameObject.transform.position.x == GuardEdges[0].x && LookingForPlayer == true || gameObject.transform.position.x == GuardEdges[1].x && LookingForPlayer == true)
		{
			StartToCountDown = true;
		}

		if(StartToCountDown == true)
		{
			AlertTime -= Time.deltaTime;
		}

		if(AlertTime < 0)
		{
			StartToCountDown = false;
			MovingTo[0] = true;
			AlertTime = StartAlertTime;
			LookingForPlayer = false;
		}

		if(LookingForPlayer == true)
		{
			if(hit.collider != null && hit.collider.gameObject == Player)
			{
				AlertTime = StartAlertTime;
				StartToCountDown = false;
			}
		}
	}
}