using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponChoose : MonoBehaviour 
{
	public Transform ShootPosition;

	public string ChoosedBullet;

	public List<GameObject> Bullets;
	public List<string> BulletType;
	public List<KeyCode> ButtomChooseWeapon; // Buttom to choose which bullet shoot.
	/*
 	0 = IceCream Bullet
	1 =  Look MachineGun
	2 = Granulate Shotgun
	3 = CoverageThrower
	4 = Cherrycket Launcher (CherryRocket Launcher)
	 */

	void Update () 
	{
		ChooseTheWeapon();
		Shoot ();
	}

	void ChooseTheWeapon()
	{
		if (Input.GetKey (ButtomChooseWeapon [0])) {
			ChoosedBullet = BulletType [0];
		}
		if (Input.GetKey (ButtomChooseWeapon [1])) {
			ChoosedBullet = BulletType [1];
		}
		if (Input.GetKey (ButtomChooseWeapon [2])) {
			ChoosedBullet = BulletType [2];
		}
		if (Input.GetKey (ButtomChooseWeapon [3])) {
			ChoosedBullet = BulletType [3];
		}
		if (Input.GetKey (ButtomChooseWeapon [4])) {
			ChoosedBullet = BulletType [4];
		}
	}

	void Shoot()
	{
		if (Input.GetKey(gameObject.GetComponent<Player>().Shoot)) 
		{
			switch (ChoosedBullet) 
			{
				case "Look MachineGun":
					Instantiate (Bullets [1], new Vector3(ShootPosition.transform.position.x,Random.Range(ShootPosition.transform.position.y - 0.1f, ShootPosition.transform.position.y + 0.1f), ShootPosition.transform.position.z), Quaternion.Euler(0,0,90));//ShootPosition.position, Quaternion.Euler(0,0,90));
				break;
				case "CoverageThrower":
					Instantiate (Bullets [3], ShootPosition.position, Quaternion.identity);
				break;
			}
		}
		if(Input.GetKeyDown(gameObject.GetComponent<Player>().Shoot))
		{
			switch (ChoosedBullet) 
			{
				case "IceCream Bullet":
					Instantiate (Bullets [0], ShootPosition.position, Quaternion.identity);
				break;
				case "Granulate Shotgun":
					Instantiate (Bullets [2], ShootPosition.position, Quaternion.identity);
				break;
				case "Cherrycket Launcher":
					Instantiate (Bullets [4], ShootPosition.position, Quaternion.identity);
				break;
			}
		}
	}
}
