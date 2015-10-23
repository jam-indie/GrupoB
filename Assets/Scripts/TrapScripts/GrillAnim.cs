using UnityEngine;
using System.Collections;

public class GrillAnim : MonoBehaviour 
{
	public Animator anim;
	public SpriteRenderer SpriteRenderer;
	public Sprite Pos;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		SpriteRenderer = GetComponent<SpriteRenderer> ();
		anim.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			anim.enabled = true;
		}
		if (Input.GetKeyUp (KeyCode.W)) 
		{
			anim.enabled = false;
			SpriteRenderer.sprite = Pos;
		}
	}
}
