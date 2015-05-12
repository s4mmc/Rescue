using UnityEngine;
using System.Collections;

public class SentryCollide : MonoBehaviour {

	public GameObject ragdoll;
	public GameObject model;
	public bool isDead = false;


	CapsuleCollider cc;
	SentrySeek ss;
	NavMeshAgent nav;


	// Use this for initialization
	void Start () {
	
		ragdoll.SetActive (false);
		cc = GetComponent<CapsuleCollider>();
		ss = GetComponent<SentrySeek>();
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Bullet") {
			Debug.Log ("Sentry hit");
			isDead = true;
			ragdoll.SetActive(true);
			model.SetActive(false);
			cc.enabled = false;
			ss.enabled = false;
			nav.enabled = false;
		}
	}

	public void RaycastHitMe(){

		Debug.Log ("Sentry hit");
		isDead = true;
		ragdoll.SetActive(true);
		model.SetActive(false);
		cc.enabled = false;
		ss.enabled = false;
		nav.enabled = false;
	}













}
