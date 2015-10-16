using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//ControllKeys
	public KeyCode Space;
	public KeyCode RightArrow;
	public KeyCode LeftArrow;

	//Physics
	private Rigidbody2D MyRigidBody;
	private int Clicks;
	public bool CanJump;
	public float JumpForce;
	public Animator Anim;
	public SpriteRenderer MySpriteRenderer;
	public Sprite MySprite;

	void Start () 
	{
		MyRigidBody = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator> ();
		MySpriteRenderer = GetComponent<SpriteRenderer> ();
		//CanJump = true;
		Anim.enabled = false;
	}

	void Update () 
	{
		Controls();
	}

	void Controls ()
	{
		if (Input.GetKey(RightArrow)) 
		{
			transform.position += new Vector3(5*Time.deltaTime,0,0);
			gameObject.transform.localScale = new Vector3(1, 1,1);
			Anim.enabled = true;
		} else
		{
			MySpriteRenderer.sprite = MySprite;
			Anim.enabled = false;
		}

		if (Input.GetKey(LeftArrow))
		{
			transform.position -= new Vector3(5*Time.deltaTime,0,0);
			gameObject.transform.localScale = new Vector3(-1, 1,1);
			Anim.enabled = true;
		}
		if (Input.GetKeyDown(Space) && CanJump == true) 
		{
			MyRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
			CanJump = false;
		}
	}
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			CanJump = true;
			Debug.Log ("Enter");
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			CanJump = false;
			Debug.Log ("Exit");
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			CanJump = true;
			Debug.Log ("Stay");
		}
	}
}
