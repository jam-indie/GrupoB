using UnityEngine;
using System.Collections;

public class CameraCorrection : MonoBehaviour 
{
	public Camera Main;

	public GameObject Player;

	public float CameraCorrectionX;
	public float CameraCorrectionY;

	public float FollowSpeed;

	public float LimitX;
	public float LimitY;

	public bool Follow;
	public bool AutomaticLimiter;//If true, the script get's the start position of player and equal the Limit X to him position X and the LimitY to him position Y.

	void Start () 
	{
		Main = Camera.main;
		Player = GameObject.Find ("Player");

		if(AutomaticLimiter)
		{
			LimitX = Player.transform.position.x;
			LimitY = Player.transform.position.y;
		}
	}

	void Update () 
	{
		if(Player.transform.position.x <= LimitX || Player.transform.position.x >= -LimitX)
		{
			Main.transform.position =  Vector3.Lerp(Main.transform.position, new Vector3(Main.transform.position.x, Player.transform.position.y + CameraCorrectionY, Main.transform.position.z), FollowSpeed);
		}
		else if(Player.transform.position.y <= LimitY || Player.transform.position.y >= -LimitY - CameraCorrectionY)
		{
			Main.transform.position =  Vector3.Lerp(Main.transform.position, new Vector3(Player.transform.position.x + CameraCorrectionX, Main.transform.position.y, Main.transform.position.z), FollowSpeed);
		}
		else
		{
			Main.transform.position =  Vector3.Lerp(Main.transform.position, new Vector3(Player.transform.position.x + CameraCorrectionX, Player.transform.position.y + CameraCorrectionY, Main.transform.position.z), FollowSpeed);
		}
	}
}