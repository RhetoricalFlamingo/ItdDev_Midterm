using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerScript : MonoBehaviour
{

	public GameObject pan;
	private float sideTime = 0;
	
	public Material rawMeat;
	public Material doneMeat;
	public Material burnMeat;

	public int side_ID = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (side_ID == 1)
		{
			sideTime = pan.GetComponent<foodScript>().side1Time;
			
			if (sideTime < 70)
				this.GetComponent<MeshRenderer>().material = burnMeat;
			if (sideTime < 40)
				this.GetComponent<MeshRenderer>().material = doneMeat;
			if (sideTime < 20)
				this.GetComponent<MeshRenderer>().material = rawMeat;
		}
		if (side_ID == 2)
		{
			sideTime = pan.GetComponent<foodScript>().side2Time;
			
			if (sideTime < 70)
				this.GetComponent<MeshRenderer>().material = burnMeat;
			if (sideTime < 40)
				this.GetComponent<MeshRenderer>().material = doneMeat;
			if (sideTime < 20)
				this.GetComponent<MeshRenderer>().material = rawMeat;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		pan.GetComponent<foodScript>().burgerOnPan = true;
	}
	
	public void OnTriggerExit(Collider other)
	{
		pan.GetComponent<foodScript>().burgerOnPan = false;
	}
}
