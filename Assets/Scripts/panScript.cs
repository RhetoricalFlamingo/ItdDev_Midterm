using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panScript : MonoBehaviour
{
	public int currentSide = 0;

	public GameObject wholePan;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		wholePan.GetComponent<foodScript>().currentSide = currentSide;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "pattySide1")	//copyPasted above collision detection because pattysides are now triggers
		{
			currentSide = 1;
			//Debug.Log("side1Contact");
		}
		
		else if (other.gameObject.tag == "pattySide2")
		{
			currentSide = 2;
			//Debug.Log("side2Contact");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.gameObject.tag == "pattySide1") || (other.gameObject.tag == "pattySide2"))
		{
			currentSide = 0;
			//Debug.Log("burgerOffPan");
		}
	}
}
