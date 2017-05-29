using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	private GameObject Volume;
	public Slider Diffic;
	AudioSource music;
	 
	//Sets music slider value to correctly represent volume value
	void Start(){
		Volume = GameObject.Find("MusicSlider");
		music = GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<AudioSource>();
		Diffic.GetComponent<Slider> ().value = GameData.Difficulty;
		Volume.GetComponent<Slider> ().value = GameData.MusicVolume;
		print (GameData.Difficulty+" -Difficulty");

		Volume.GetComponent<Slider>().value = music.volume;
	}


	//Updates volume based on slider
	public void UpdateVolume () {
		music.volume = Volume.GetComponent<Slider>().value;
		if(Volume.GetComponent<Slider>().value == 0){
			GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<DonotDestroyOnLoad>().setMuted(true);
		}else{
			GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<DonotDestroyOnLoad>().setMuted(false);
		}
		GameData.MusicVolume = Volume.GetComponent<Slider> ().value;
	}

	//Saves game
	public void SaveData(){
		GameData.Save ();
	}

	//Changes difficulty according to slider
	public void ChangeDiff(){
		GameData.Difficulty = (int)Diffic.GetComponent<Slider> ().value;
	}
}
