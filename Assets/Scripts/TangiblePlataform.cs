using UnityEngine;
using System.Collections;

public class TangiblePlataform : MonoBehaviour 
{
	public bool IsTangible;
	public Collider2D MyCollider;
	public GameObject Player;
	
	void Start () 
	{
		MyCollider = gameObject.GetComponent<Collider2D> ();
		Player = GameObject.Find("Player");
	}

	void Update () 
	{
		if(IsTangible)
		{
			if(Player.transform.position.y < this.gameObject.transform.position.y)
			{
				this.MyCollider.isTrigger = true;
			}

			if(Player.transform.position.y > this.gameObject.transform.position.y + this.gameObject.transform.localScale.y)
			{
				this.MyCollider.isTrigger = false;
			}
		}
	}
}
