using UnityEngine;
using System.Collections;

public class HostageFollow : MonoBehaviour {

	public GameObject player;

	private Vector3 targetPos;
	private bool follow;
	private bool inRange;

	void Update(){
		Follow();
		Debug.Log ("follow: " + follow + System.Environment.NewLine + "inRange: " + inRange);
	}


	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "Player") {
			inRange = true;
			transform.LookAt(targetPos);
			if(Input.GetKeyDown (KeyCode.E) && follow == false){
				follow = true;
				Debug.Log("Follow Started");
			}
			else if(Input.GetKeyDown (KeyCode.E) && follow == true){
				follow = false;
				Stay();

			}
		}
	}

	void OnTriggerExit(){
		inRange = false;
	}

	void Stay(){
		transform.position = transform.position;
	}

	void Follow(){
		if(follow == true && inRange == false){
		Debug.Log ("FOLLOWING");
		targetPos = player.transform.position;
		targetPos.z -= 1;
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime);
			transform.LookAt(targetPos);
		}
		else if(follow == true && inRange == true){
			Stay();
		}
		else if (follow == false){
			Stay();
		}
	}

}
