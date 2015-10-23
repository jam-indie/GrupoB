using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shell : MonoBehaviour 
{
	public Transform FollowPoint;
	public GameObject ShellPart;
	public GameObject ShellCablePivot;

	public float RotationSpeed;

	public List<int> Limits;

	void Start () 
	{
		this.ShellCablePivot = this.gameObject.transform.FindChild ("ShellCablePivot").gameObject;

		this.FollowPoint = ShellCablePivot.gameObject.transform.FindChild("ShellCable").gameObject.transform.FindChild("FollowPoint");

		this.ShellPart = this.gameObject.transform.FindChild ("Shell").gameObject;
	}

	void Update () 
	{
		this.ShellPart.transform.position = FollowPoint.position;

		this.ShellCablePivot.transform.Rotate (new Vector3(0,0, RotationSpeed) * Time.deltaTime);

		if(this.ShellCablePivot.transform.localEulerAngles.z <= Limits[0] || this.ShellCablePivot.transform.localEulerAngles.z >= Limits[1])//Left Limit and Right Limit
		{
			RotationSpeed *= -1;
		}
	} 
}
