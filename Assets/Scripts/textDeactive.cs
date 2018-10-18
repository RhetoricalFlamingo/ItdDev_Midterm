using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textDeactive : MonoBehaviour
{

	public float i = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.GetComponent<Text>().text == "+10 Points")
		{
			i += Time.deltaTime;

			if (i >= 1)
			{
				this.GetComponent<Text>().text = "";
				i = 0;
			}
		}
	}
}
