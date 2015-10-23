using UnityEngine;
using System.Collections;

public class InfinityRotation : MonoBehaviour 
{
	public float yRotation;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		yRotation += Input.GetAxis("Horizontal");
		transform.eulerAngles -= new Vector3(0,0, yRotation);
	}
}
