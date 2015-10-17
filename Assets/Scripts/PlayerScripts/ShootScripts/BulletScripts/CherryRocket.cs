using UnityEngine;
using System.Collections;

public class CherryRocket : MonoBehaviour 
{
	public GameObject Player;
	public float BulletSpeed;
	public float RotateSpeed;
	
	void Start()
	{
		Player = GameObject.Find ("Player");
		this.BulletSpeed = this.BulletSpeed * Player.transform.localScale.x; // This line correct the direction of shoot;
	}
	
	void Update () 
	{
		gameObject.transform.position += new Vector3 (BulletSpeed, 0, 0);
		gameObject.transform.Rotate( RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime);
	}
	
	void OnBecameInvisible()//If objectj is out of camera range, do something
	{
		Destroy(this.gameObject);
	}
}
