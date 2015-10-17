using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LookMachineGunBullet : MonoBehaviour 
{
	public GameObject Player;
	public float BulletSpeed;
	
	void Start()
	{
		Player = GameObject.Find ("Player");
		this.BulletSpeed = this.BulletSpeed * Player.transform.localScale.x; // This line correct the direction of shoot;
	}
	
	void Update () 
	{
		this.gameObject.transform.position += new Vector3 (BulletSpeed, 0, 0);
	}
	
	void OnBecameInvisible()//If objectj is out of camera range, do something
	{
		Destroy(this.gameObject);
	}
}
