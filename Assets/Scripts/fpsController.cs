using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fpsController : MonoBehaviour
{

	public GameObject playerCam;
	public GameObject pan;
	public Rigidbody playerRB;

	public float lookSensitiv = 0;
	public float moveSpeed = 0;
	private Vector3 inputVector;
	
	bool cursorInactive = true;

	public GameObject controls;
	
	// Use this for initialization
	void Start ()
	{
		playerRB = this.GetComponent<Rigidbody>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float vert = Input.GetAxis("Vertical");
		float horiz = Input.GetAxis("Horizontal");

		inputVector = transform.forward * vert * moveSpeed;
		inputVector += transform.right * horiz * moveSpeed;
		
		if (pan.GetComponent<foodScript>().playerAtPot == false)
			camControl();

		if (Input.GetKey(KeyCode.R))
		{
			float resetI = 0;
			resetI += Time.deltaTime;
			if (resetI > 3)
			{
				Application.Quit();
			}
		}
		if (Input.GetKeyUp(KeyCode.R))
		{
			SceneManager.LoadScene("testScene");
		}
		
		if (cursorInactive && Input.GetKeyDown(KeyCode.Escape))	//make cursor visible and moving again
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			cursorInactive = false;
		}
		
		if (!cursorInactive && Input.GetKeyDown(KeyCode.Mouse0))	//make cursor invisible and locked on mouse
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			cursorInactive = true;
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			controls.SetActive(true);
		}
		else controls.SetActive(false);
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
