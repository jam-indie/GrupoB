using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//ControllKeys

	public KeyCode Space; //Jump
	public KeyCode RightArrow; // Move to right
	public KeyCode LeftArrow; // Move to Left
	public KeyCode Shoot; //Shoot the choosedBullet;
	
	//Physics

	public bool CanJump;
	public float JumpForce;
	public float MovimentSpeed;
	public Sprite MySprite;
	private SpriteRenderer MySpriteRenderer;
	private Rigidbody2D MyRigidBody;
	private Animator Anim;

	//Double jump

	private int JumpCount; //Count how many jumps the player has
	public bool DoubleJump; // this boolean activate the double jump or not

	void Start () 
	{
		MyRigidBody = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator> ();
		MySpriteRenderer = GetComponent<SpriteRenderer> ();
		Anim.enabled = false;
	}

	void Update () 
	{
		Controls();
		DoubleJumpActivate();
	}

	void Controls ()
	{
		MySpriteRenderer.sprite = MySprite;
		Anim.enabled = false;

		if (Input.GetKey(RightArrow)) 
		{
			transform.position += new Vector3(MovimentSpeed*Time.deltaTime,0,0);
			gameObject.transform.localScale = new Vector3(1,1,1);
			Anim.enabled = true;
		}
		if (Input.GetKey(LeftArrow))
		{
			transform.position -= new Vector3(MovimentSpeed*Time.deltaTime,0,0);
			gameObject.transform.localScale = new Vector3(-1,1,1);
			Anim.enabled = true;
		}
		if (Input.GetKeyDown(Space) && CanJump == true) 
		{
			MyRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
		}
	}//End of Controls void

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			CanJump = true;
			JumpCount = 0;
		}

		if (coll.gameObject.tag == "Cubo")
		{	
			Debug.Log ("Test");
			coll.gameObject.SetActive(false); // Quando o player entrar em contato com o objeto, somara um ponto e esse objeto fica desativado.
			GameObject.Find("Score").GetComponent<Score>().score = GameObject.Find("Score").GetComponent<Score>().score + 1;
		}
	}//End of OnCollisionEnter2D

	void OnCollisionExit2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			if(!DoubleJump)
			{
				CanJump = false;
			}
		}
	}//End of OnCollisionExit2D

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			CanJump = true;
			JumpCount = 0;
		}
	}//End of OnCollisionStay2D

	void DoubleJumpActivate()
	{
		if(DoubleJump)
		{
			if (Input.GetKeyDown(Space) && CanJump == true) 
			{
				JumpCount ++;
				if(JumpCount >= 1)
				{
					CanJump = false;
				}
				else
				{
					CanJump = true;
				}
			}
		}
	}//End of DoubleJumpActivate void
}