using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour 
{
	public Rigidbody pular;

	// Use this for initialization
	void Start () 
	{
		pular = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += new Vector3(4*Time.deltaTime,0,0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= new Vector3(4*Time.deltaTime,0,0);
		} 
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			pular.AddForce(0,16,0, ForceMode.Impulse);
		}
	}
}
