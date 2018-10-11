using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerParentScript : MonoBehaviour
{

	public GameObject pan;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		this.GetComponent<Rigidbody>().AddForce(.1f, 0, .1f);
	}

	private void OnCollisionStay(Collision other)
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && pan.GetComponent<foodScript>().playerAtPot)
		{
			float burgerXRange = this.transform.position.x + Random.Range(-2, 2);
			float burgerZRange = this.transform.position.z + Random.Range(-2, 2);
			
			this.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 3, 0),
				this.transform.position + new Vector3(burgerXRange, 0, burgerZRange),
				ForceMode.Impulse);
		}

		Debug.Log("collStay");
	}
}
