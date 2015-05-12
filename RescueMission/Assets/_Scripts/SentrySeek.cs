using UnityEngine;
using System.Collections;

public class SentrySeek : MonoBehaviour {

	//declare a public variable to reference the Main Camera
	public GameObject gc;
	public const float PROXIMITY_DISTANCE = 0.5f;
	private GameObject currentTarget;
	private SentryWaypoints waypointManager;
	//const float DECELERATION_FACTOR = 0.6f;
	Animator myAnim;
	
	
	//now variables needed by FixedUpdate
	Vector3 source;
	public Vector3 target;
	Vector3 outputVelocity;

	public SentryCollide sentryColl;
	
	//and arrive
	Vector3 directionToTarget;
	Vector3 velocityToTarget;
	float distanceToTarget;
	float speed;
	
	//public variable reference to playerDetect script and sensesPlayer bool
	public bool inRange;
	public GameObject playerPos;
	public bool attackRange;
	
	
	
	// Use this for initialization
	void Awake () {
		
		//get the WaypointManager from the camera and then the first object
		waypointManager = gc.GetComponent<SentryWaypoints>();
		currentTarget = waypointManager.NextWaypoint(null);
		myAnim = GetComponent<Animator> ();
		sentryColl = GetComponent<SentryCollide> ();
		
		
	}
	
	
	
	void FixedUpdate () {
		
		//checks sensesPlayer bool
		inRange = GetComponentInChildren<PlayerDetect> ().sensesPlayer;
		
		//	Debug.Log (currentTarget.gameObject.name);
		
		playerPos = GameObject.Find ("Player");
		
		source = transform.position;
		target = currentTarget.transform.position;
		outputVelocity = Arrive(source, target);
		GetComponent<Rigidbody>().AddForce( outputVelocity, ForceMode.VelocityChange );
		
		Sentry ();
		
		//Look at current waypoint
		LookAtNextWaypoint ();
	}
	
	//Sentry function 
	void Sentry(){


			//check the distance from object to target, and make query
			//when it moves within the PROXIMITY_DISTANCE
			if (Vector3.Distance (source, target) < PROXIMITY_DISTANCE && currentTarget.name != "Player") {
				currentTarget = waypointManager.NextWaypoint (currentTarget);
				attackRange = false;
			} else if (inRange == true) {
				currentTarget = playerPos;
			
				if (inRange == true && Vector3.Distance (source, target) < PROXIMITY_DISTANCE) {
					attackRange = true;
				} else {
					attackRange = false;
				}
			} else if (inRange == false && currentTarget.name == "Player") {
				currentTarget = waypointManager.NextWaypoint (null);
			}

		 
		
	}
	
	//arrive function
	private Vector3 Arrive(Vector3 source, Vector3 target){

			distanceToTarget = Vector3.Distance (source, target);
			directionToTarget = Vector3.Normalize (target - source);
		
			//charlies spped code replaced with a constant speed to stop crazy AI run speed
	
			if (inRange == false) {
				speed = 6f; 
			} else {
				speed = 10f;
			}
			//	myAnim.SetFloat ("speed", speed);

		
		velocityToTarget = speed * directionToTarget;
		return velocityToTarget - GetComponent<Rigidbody>().velocity;
		
	}
	
	
	
	private void LookAtNextWaypoint(){
		Vector3 targetPos = currentTarget.transform.position;
		transform.LookAt (targetPos);
	}
}
