using UnityEngine;
using System.Collections;

public class Alarms : MonoBehaviour {
	public GameObject lights;
	public SentrySeek sentry;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (Vector3.up);
		if (sentry.inRange == true) {
			lights.SetActive(true);
		} else {
			lights.SetActive(false);
		}
	}
}
