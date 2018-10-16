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
		if (other.gameObject.tag == "pan" && pan.GetComponent<foodScript>().playerAtPot)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				float burgerXRange = this.transform.position.x + Random.Range(-2, 2);
				float burgerZRange = this.transform.position.z + Random.Range(-2, 2);

				this.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, 3, 0),
					this.transform.position + new Vector3(burgerXRange, 0, burgerZRange),
					ForceMode.Impulse);
			}

			this.GetComponent<Rigidbody>().AddForce(Input.GetAxis("mouseX") * Time.deltaTime * 10, 0, Input.GetAxis("mouseY") * Time.deltaTime * 10);
		}

		//Debug.Log("collStay");
	}
}
