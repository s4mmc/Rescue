using UnityEngine;
using System.Collections;

public class BulletMotion : MonoBehaviour {
	private Rigidbody rb;
	public Transform goTo;
	public Transform spawn;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
	

	}

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	//	transform.parent = spawn;
	}
	
	// Update is called once per frame
	void Update () {
		direction = goTo.position - spawn.position;
		rb.AddRelativeForce (-spawn.transform.forward * 6000f);
	}
}
