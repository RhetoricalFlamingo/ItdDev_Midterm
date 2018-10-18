using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointPickupScript : MonoBehaviour
{

	public GameObject pan;
	float i = 0f;
	public GameObject scorePlus;
	
	// Use this for initialization
	void Start () {
		pan = GameObject.FindWithTag("pan");
		scorePlus = GameObject.FindWithTag("scorePlus");
	}
	
	// Update is called once per frame
	void Update ()
	{
		i += Time.deltaTime;

		if (i >= 8)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		pan.GetComponent<foodScript>().pointsI += 10;
		scorePlus.GetComponent<Text>().text = "+10 Points";
		Destroy(this.gameObject);
	}
}
