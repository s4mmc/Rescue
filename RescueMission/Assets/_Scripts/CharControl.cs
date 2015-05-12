using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour {

	// MovePlayer() Variables
	public bool isRunning;
	public bool jumped;
	public bool isCrouched;
	public float jumpPower = 650f;
	public float walkSpeed = 5f;
	public float runSpeed = 10f;
	private float speed;
	public Rigidbody rb;

	private CapsuleCollider myCollider;

	//CamLook variables
	public Transform cam;
	Vector3 yRot;	
	float yRotation;
	float ySensivity = 2f;
	float lookSpeed = 5f;

	

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		myCollider = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {

		JumpPower ();
		MovePlayer ();
		CamLook ();
		Crouch ();

	}

	void MovePlayer(){

		if(Input.GetKey(KeyCode.LeftShift)){
			isRunning = true;
			speed = runSpeed;
		}
		else{
			isRunning = false;
			speed = walkSpeed;
		}

		// front and back
		if (Input.GetKey (KeyCode.W) && isRunning == false) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);

			
			
		} else if (Input.GetKey (KeyCode.S) && isRunning == false) {
			transform.Translate (-Vector3.forward * speed * Time.deltaTime);

		}

		//running
		
		else if(Input.GetKey (KeyCode.W) && isRunning == true){
			transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

		}
		else if(Input.GetKey (KeyCode.S) && isRunning == true){
			transform.Translate(-Vector3.forward * runSpeed * Time.deltaTime);

		}

		//left and right
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);

			
			
		} else if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector3.right * speed * Time.deltaTime);

			
			
		} else {

		}
		
		if (Input.GetButtonUp("Jump") && jumped == false){
			rb.AddForce(Vector3.up * jumpPower);
			jumpPower = 650f;
			jumped = true;
		}

		// Rotate Player with mouse
		if (Input.GetAxisRaw ("Mouse X") != 0f) {
			transform.Rotate (Vector3.up * lookSpeed * Input.GetAxisRaw ("Mouse X"));
		}
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Ground") {
			jumped = false;
		}
	}

	void CamLook(){


		
		yRotation += Input.GetAxis("Mouse Y") * ySensivity;
		yRotation = Mathf.Clamp (yRotation, -60, 60);
		
		//cam.localEulerAngles = new Vector3(-yRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
		cam.rotation = Quaternion.Euler(-yRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

		}

	void JumpPower(){
		if(Input.GetKey(KeyCode.Space)){
			jumpPower += 50f * Time.deltaTime;
			Mathf.Clamp(jumpPower, 650f, 850f);

		}
	}


	void Crouch(){
		if (Input.GetKey (KeyCode.LeftControl)) {
			myCollider.height = 2f;
			walkSpeed = 4f;
			runSpeed = 4f;
			isCrouched = true;
		} else {
			myCollider.height = 3f;
			walkSpeed = 5f;
			runSpeed = 10f;
			isCrouched = false;
		}
	}

}