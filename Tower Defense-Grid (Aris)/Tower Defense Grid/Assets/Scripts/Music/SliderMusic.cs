using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour {

	public Slider Volume;
	 AudioSource music;
	 
	void Start(){
		Volume.value = music.volume;
	}
	// Update is called once per frame
	void Update () {
		music = GameObject.FindGameObjectWithTag ("backroundmusic").GetComponent<AudioSource> ();
		music.volume = Volume.value;
	}

}
