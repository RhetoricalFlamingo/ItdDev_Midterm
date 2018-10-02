using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class spotifyScript : MonoBehaviour
{

	public AudioSource source;
	public GameObject albumArt;
	public Image timeRemainingInSongBar;
	
	public AudioClip[] songs = new AudioClip[5];
	public Sprite[] albums = new Sprite[5];
	
	private float songTimeSince0 = 0;
	private float songTimeRemaining = 0;
	
	private int i = 0;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Period) || songTimeRemaining >= 1)
		{
			i++;
			if (i > songs.Length - 1)
			{
				i = 0;
			}

			source.clip = songs[i];
			albumArt.GetComponent<Image>().sprite = albums[i];
			
			songTimeSince0 = 0;
			source.Play();

		}
		if (Input.GetKeyDown(KeyCode.Comma))
		{
			i--;
			if (i < 0)
			{
				i = songs.Length - 1;
			}
			
			source.clip = songs[i];
			albumArt.GetComponent<Image>().sprite = albums[i];
			
			songTimeSince0 = 0;
			source.Play();
		}

		songTimeSince0 += Time.deltaTime;
		songTimeRemaining = songTimeSince0 / source.clip.length;
		timeRemainingInSongBar.fillAmount = songTimeRemaining;
	}
}
