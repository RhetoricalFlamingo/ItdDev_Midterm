using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class burgerParentScript : MonoBehaviour
{

	public GameObject pan;

	private bool endStateActive = false;
	private float i = 0;

	private float force = 0;
	
	// Use this for initialization
	void Start () {
		
	}

	void Update ()
	{
		if (endStateActive)
			EndState();
	}
	
	void FixedUpdate ()
	{
		this.GetComponent<Rigidbody>().AddForce(.1f, 0, .1f);
	}

	private void OnCollisionStay(Collision other)
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			force = 0;
		}
		
		if (Input.GetKey(KeyCode.Mouse0))
		{
			force += Time.deltaTime * 10;
		}
		
		if (other.gameObject.tag == "pan")// && pan.GetComponent<foodScript>().playerAtPot)
		{
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				float burgerXRange = this.transform.position.x + Random.Range(-2, 2);
				float burgerZRange = this.transform.position.z + Random.Range(-2, 2);

				this.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, force, 0),
					this.transform.position + new Vector3(burgerXRange, 0, burgerZRange),
					ForceMode.Impulse);
			}

			this.GetComponent<Rigidbody>().AddForce(Input.GetAxis("mouseX") * Time.deltaTime * 10, 0, Input.GetAxis("mouseY") * Time.deltaTime * 10);
		}

		//Debug.Log("collStay");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "kill")
		{
			endStateActive = true;
		}
	}

	public void EndState()
	{
		i += Time.deltaTime;

		if (i > 1)
		{
			SceneManager.LoadScene("testScene");
		}
		
		Debug.Log("i = " + i);
	}
}
