using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plateScript : MonoBehaviour
{

	public GameObject resultsScreen;
	float i = 0;
	
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
		}
	}
}
