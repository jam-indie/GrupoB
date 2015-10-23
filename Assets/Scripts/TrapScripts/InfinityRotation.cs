using UnityEngine;
using System.Collections;

public class InfinityRotation : MonoBehaviour 
{
	public float ZRotation;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//ZRotation += Input.GetAxis("Horizontal");
		transform.eulerAngles += new Vector3(0,0, ZRotation * 0.25f);
	}
}
