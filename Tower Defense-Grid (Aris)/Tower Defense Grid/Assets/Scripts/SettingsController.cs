using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	private GameObject Volume;
	public Slider Diffic;
	AudioSource music;
	 
	void Start(){
		Volume = GameObject.Find("MusicSlider");
		music = GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<AudioSource>();
		Diffic.GetComponent<Slider> ().value = GameData.Difficulty;
		Volume.GetComponent<Slider> ().value = GameData.MusicVolume;
		print (GameData.Difficulty+" -Difficulty");
	//	print("Music Volume:" + music.getComponent<D> + ",Slider thinks:" + Volume.GetComponent<Slider>().value);

		Volume.GetComponent<Slider>().value = music.volume;
	}

	public void UpdateVolume () {
		music.volume = Volume.GetComponent<Slider>().value;
		if(Volume.GetComponent<Slider>().value == 0){
			GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<DonotDestroyOnLoad>().setMuted(true);
		}else{
			GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<DonotDestroyOnLoad>().setMuted(false);
		}
		GameData.MusicVolume = Volume.GetComponent<Slider> ().value;
	}

	public void SaveData(){
		GameData.Save ();
	}

	public void ChangeDiff(){
		GameData.Difficulty = (int)Diffic.GetComponent<Slider> ().value;
	}
}
