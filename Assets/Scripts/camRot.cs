using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class camRot : MonoBehaviour
{

	public float maxRot;
	public bool goingRight = true;

	private float i = 2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!goingRight)
		{
			this.transform.eulerAngles += new Vector3(0, 0, Time.deltaTime);

			i += Time.deltaTime;
			
			if (i > maxRot)
			{
				goingRight = true;
				i = 0;
			}
		}
		else
		{
			this.transform.eulerAngles -= new Vector3(0, 0, Time.deltaTime);

			i += Time.deltaTime;
			
			if (i > maxRot)
			{
				goingRight = false;
				i = 0;
			}
		}
	}
}
