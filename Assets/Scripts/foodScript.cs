using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodScript : MonoBehaviour
{

	public GameObject burgerPatty;
	public GameObject playerCam;
	public GameObject player;
	public GameObject foodCam;
	public GameObject plate;
	public Text scoreText;
	
	public bool playerAtPot = false;
	private bool plateOut = false;
	
	public float panSpeedX = 0;
	public float panSpeedY = 0;

	public float side1Time = 0;
	public float side2Time = 0;
	public float perfectTime = 0;
	public float foodQuality = 0;

	public int currentSide = 0;
	
	public bool burgerOnPan = false;

	public float pointsI = 0;
	public float pointsMax = 0;
	float burnDecrem = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSide == 1)	//INCREMENT CURRENTLY COOKING SIDE
		{
			side1Time += Time.deltaTime;
		}
		
		else if (currentSide == 2)
		{
			side2Time += Time.deltaTime;
		}

		if (playerAtPot)
		{
			playerCam.SetActive(false);
			//player.GetComponent<MeshRenderer>().setactive(false);
			foodCam.SetActive(true);
			
			movePan();	//mouse controls pan x and z
			
			if (Input.GetKeyDown(KeyCode.Space))	//PRESS SPACE TO CHANGE FROM PAN TO PLATE CONTROL
			{
				if (plateOut)
				{
					plateOut = false;
					plate.SetActive(false);
				}
				else
				{
					plateOut = true;
					plate.SetActive(true);
				}
			}

			if (Input.GetKeyDown(KeyCode.E))	//LEAVE COOKSTATION
			{
				playerAtPot = true;
			}
		}
		else
		{
			playerCam.SetActive(true);
			foodCam.SetActive(false);
		}

		foodQuality = (((side1Time + side2Time) / perfectTime) * 100);	// time on pan (where 100 is perfectly cooked)
		if ((currentSide == 1 && side1Time > 40) || (currentSide == 2 && side2Time > 40))
		{
			burnDecrem += Time.deltaTime * 400f;
			
			foodQuality -= Time.deltaTime * burnDecrem;
			Debug.Log("burning");
		}
		              
		pointsMax = (int) (foodQuality + pointsI);
		
		scoreText.text = pointsMax + " Points";
	}

	/*private void OnCollisionEnter(Collision other)	//DECIDE CURRENT FOOD SIDE COOKING
	{
		if (other.gameObject.tag == "pattySide1")
		{
			currentSide = 1;
		}
		
		else if (other.gameObject.tag == "pattySide2")
		{
			currentSide = 2;
		}
	}

	private void OnCollisionExit(Collision other)	//DONT COOK EITHER SIDE WHEN NOT TOUCHING ANYTHING
	{
		if ((other.gameObject.tag == "pattySide1") || (other.gameObject.tag == "pattySide2"))
		{
			currentSide = 0;
		}
	}*/

	private void OnTriggerEnter(Collider other)	//ENTER COOKSTATION
	{
		if (other.tag == "Player" )//&& Input.GetKeyDown(KeyCode.E))
		{
			playerAtPot = true;
			Debug.Log("playeratpot");
		}
		
		if (other.gameObject.tag == "pattySide1")	//copyPasted above collision detection because pattysides are now triggers
		{
			currentSide = 1;
			Debug.Log("side1Contact");
		}
		
		else if (other.gameObject.tag == "pattySide2")
		{
			currentSide = 2;
			Debug.Log("side2Contact");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.gameObject.tag == "pattySide1") || (other.gameObject.tag == "pattySide2"))
		{
			currentSide = 0;
			Debug.Log("burgerOffPan");
		}
	}

	public void movePan()
	{
		this.transform.position += new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * panSpeedX * 5, 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * panSpeedY;
	}
}
