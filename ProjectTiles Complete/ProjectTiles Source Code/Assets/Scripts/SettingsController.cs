using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Διαχειρίζεται την οθόνη των settings
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

	//Καλείται όταν πατηθεί το κουμπί return στην οθόνη των settings ώστε να αποθηκευτούν τυχόν αλλαγές που έχει κάνει ο παίκτης
	public void SaveData(){
		GameData.Save ();
	}

	//Changes difficulty according to slider
	//όποτε μέσω του slider ο παίκτης αλλάχει τιμή στο επίπεδο δυσκολίας η αλλαγή περνάει και στην GameData
	public void ChangeDiff(){
		GameData.Difficulty = (int)Diffic.GetComponent<Slider> ().value;
	}
}
