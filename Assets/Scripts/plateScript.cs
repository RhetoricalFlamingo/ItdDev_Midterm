using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class plateScript : MonoBehaviour
{

	public GameObject resultsScreen;
	public GameObject finalScore;
	public GameObject controlsPrompt;
	public GameObject playerPhone;
	public GameObject regPoints;
	
	float i = 0;

	public GameObject pan;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionStay(Collision other)
	{
		
		i += Time.deltaTime;

		if (i >= 1.5f)
		{
			resultsScreen.SetActive(true);
			finalScore.SetActive(true);
			controlsPrompt.SetActive(false);
			playerPhone.SetActive(false);
			regPoints.SetActive(false);

			pan.GetComponent<foodScript>().panSpeedX = 0;
			pan.GetComponent<foodScript>().panSpeedY = 0;
			
			finalScore.GetComponent<Text>().text = pan.GetComponent<foodScript>().pointsMax + " Points";
			
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
