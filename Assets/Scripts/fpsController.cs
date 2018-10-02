using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsController : MonoBehaviour
{

	public GameObject playerCam;
	public GameObject pan;
	public Rigidbody playerRB;

	public float lookSensitiv = 0;
	public float moveSpeed = 0;
	private Vector3 inputVector;
	
	// Use this for initialization
	void Start ()
	{
		playerRB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float vert = Input.GetAxis("Vertical");
		float horiz = Input.GetAxis("Horizontal");

		inputVector = transform.forward * vert * moveSpeed;
		inputVector += transform.right * horiz * moveSpeed;
		
		if (pan.GetComponent<foodScript>().playerAtPot == false)
			camControl();
	}
	
	void FixedUpdate () {
		if (pan.GetComponent<foodScript>().playerAtPot == false)
			playerMove();
	}

	void camControl()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		
		this.transform.Rotate(-mouseY * lookSensitiv * Time.deltaTime, mouseX * lookSensitiv * Time.deltaTime, 0);
		this.transform.localEulerAngles -= new Vector3(
			0, 
			0,
			this.transform.localEulerAngles.z);
	}

	void playerMove()
	{
		playerRB.velocity = inputVector;
		//this.transform.Translate(horiz * moveSpeed * Time.deltaTime, 0, vert * moveSpeed * Time.deltaTime);
	}
}
