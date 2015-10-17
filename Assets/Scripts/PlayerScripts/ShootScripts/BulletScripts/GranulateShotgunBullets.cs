using UnityEngine;
using System.Collections;

public class GranulateShotgunBullets : MonoBehaviour 
{
	public GameObject Player;
	public float BulletSpeed;
	public float RotateSpeed;
	
	public GameObject AdjacentBulletUp;
	public GameObject AdjacentBulletUpMid;
	public GameObject AdjacentBulletDownMid;
	public GameObject AdjacentBulletDown;

	void Start()
	{
		Player = GameObject.Find ("Player");
		this.BulletSpeed = this.BulletSpeed * Player.transform.localScale.x; // This line correct the direction of shoot;

		AdjacentBulletUp = this.gameObject.transform.FindChild("AdjacentBulletUp").gameObject;
		AdjacentBulletUpMid = this.gameObject.transform.FindChild("AdjacentBulletUpMid").gameObject;
		AdjacentBulletDownMid = this.gameObject.transform.FindChild("AdjacentBulletDownMid").gameObject;
		AdjacentBulletDown = this.gameObject.transform.FindChild("AdjacentBulletDown").gameObject;
	}
	
	void Update () 
	{
		AdjacentBulletUp.transform.position += new Vector3 (-BulletSpeed/2, BulletSpeed, 0);
		//this.AdjacentBullet1.transform.Rotate( 0, 0, RotateSpeed * Time.deltaTime);

		AdjacentBulletUpMid.transform.position += new Vector3 (-BulletSpeed/4, BulletSpeed/2, 0);
		//this.AdjacentBullet1.transform.Rotate( 0, 0, RotateSpeed * Time.deltaTime);

		gameObject.transform.position += new Vector3 (BulletSpeed, 0, 0);
		//this.gameObject.transform.Rotate( 0, 0, RotateSpeed * Time.deltaTime);

		AdjacentBulletDownMid.transform.position += new Vector3 (-BulletSpeed/4, -BulletSpeed/2, 0);
		//this.AdjacentBullet2.transform.Rotate( 0, 0, RotateSpeed * Time.deltaTime);

		AdjacentBulletDown.transform.position += new Vector3 (-BulletSpeed/2, -BulletSpeed, 0);
		//this.AdjacentBullet2.transform.Rotate( 0, 0, RotateSpeed * Time.deltaTime);
	}
	
	void OnBecameInvisible()//If objectj is out of camera range, do something
	{
		Destroy(this.gameObject);
	}
}