using UnityEngine;
using System.Collections;

public class PlayerDetect : MonoBehaviour {

	public Transform player;
	public Transform AI;

	public CharControl playerControler;

	private GameObject waypointManager;
	private Vector3 targetDirection;
	private float angle;
	private float targetDistance;

	public bool sensesPlayer = false;

	SphereCollider detectionRange;

	// Use this for initialization
	void Start () {
	
		detectionRange = GetComponent<SphereCollider> ();

		waypointManager = GameObject.Find ("WayPointManager");

	}
	
	// Update is called once per frame
	void Update () {
	
		LineOfSight ();
//		Debug.Log (sensesPlayer);
//		Debug.Log(angle);
//		Debug.Log(targetDistance);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Player" && playerControler.isCrouched == false) {

			//Debug.Log ("!!!PLAYER FOUND!!!");
			detectionRange.radius = 6f;
			sensesPlayer = true;


		} 
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){

			//Debug.Log ("!!!PLAYER LOST!!!");
			detectionRange.radius = 1.5f;
			sensesPlayer = false;
		}

	}



	void LineOfSight(){
		targetDirection = player.position - AI.position;
		RaycastHit hit;
		Vector3 fwd = transform.forward;
		angle = Vector3.Angle (targetDirection, fwd);
		targetDistance = Vector3.Distance (player.position, AI.position);
		if (angle < 45f && Physics.Raycast(AI.position, targetDirection, out hit)) {
			if(hit.transform.name == "Player"){
			Debug.Log("I SEE YOU");
			sensesPlayer = true;
		} else {
			sensesPlayer = false;
		}
	}
	}
}
