using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSpawner : MonoBehaviour
{

	public GameObject point;
	private Vector3 randomTransform;

	private float i = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		i += Time.deltaTime;

		if (i >= 6.5)
		{
			spawnPoint();
			i = 0;
		}
	}

	void spawnPoint()
	{
		randomTransform = new Vector3(Random.Range(-1f, 1f), Random.Range(1.5f, 2.25f), Random.Range(1.75f, 1.35f));

		GameObject pointInstance = point;
		pointInstance = Instantiate(point, randomTransform, Quaternion.identity);
	}
}
