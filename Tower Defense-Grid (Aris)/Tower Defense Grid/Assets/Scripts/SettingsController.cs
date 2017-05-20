using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Slider Volume;
	public Slider Diffic;
	AudioSource music;
	 
	void Start(){
		
		Diffic.GetComponent<Slider> ().value = GameData.Difficulty;
		print (GameData.Difficulty+" -Difficulty");
		Volume.GetComponent<Slider>().value = music.volume;
	}
	// Update is called once per frame
	void Update () {
		music = GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<AudioSource> ();
		music.volume = Volume.value;
	}

}
