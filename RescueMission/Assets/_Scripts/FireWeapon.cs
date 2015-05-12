using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour {

	public GameObject bullet;
	public Transform bulletSpawn;

	public Rigidbody bulletRB;
	private float speed = 600f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FireShot ();
	}

	void FireShot(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			/*
			 * 
			 * 
			GameObject newBullet = Instantiate(bullet, bulletSpawn.position, transform.rotation) as GameObject;
			//newBullet.transform.parent = bulletSpawn;
			bulletRB = newBullet.GetComponent<Rigidbody>();
			bulletRB.velocity = bulletSpawn.TransformDirection(Vector3.forward * speed);
			*
			*
			*/

			RaycastHit hit;
			if(Physics.Raycast(bulletSpawn.position, bulletSpawn.TransformDirection(Vector3.forward), out hit, 75f))
				if(hit.transform.tag == "Enemy"){
				Debug.Log ("HIT ENEMY");
				SentryCollide coll = hit.transform.gameObject.GetComponent<SentryCollide>();
				coll.RaycastHitMe();
			}
		}

	}
}
