using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
	private Rigidbody playerRB;
	private Vector2 inputVector;
	
	public float moveSpeed = 0;
	public float rotSpeed = 0;
	
	// Use this for initialization
	void Start ()
	{
		playerRB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		inputVector = new Vector2(horiz, vert);
	}

	void FixedUpdate()
	{
		playerRB.AddRelativeForce(transform.forward * inputVector.y * moveSpeed);
		playerRB.AddRelativeTorque(transform.up * inputVector.x * rotSpeed);
	}
}
