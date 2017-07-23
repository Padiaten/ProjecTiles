using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Διαχειρίζεται το tetx που δείχνει πόσα waves έχεις παίξει και πόσα υπάρχουν συνολικά ή αν είναι στο survival μόνο πόσα έχει παίξει
public class WaveTextController : MonoBehaviour {

	private bool survival = LevelHandler.IsSurvival;

	void Start(){
		if (!survival)
			GetComponent<Text> ().text = "WAVE:" + GameObject.Find ("GameFlow").GetComponent<WaveControler> ().WavesIndex.ToString () + "/" + LevelHandler.GetSelectedWave () [0].Count.ToString ();
		else
			GetComponent<Text> ().text = "WAVE:" + GameObject.Find ("GameFlow").GetComponent<WaveControler> ().WavesIndex.ToString ();
	}

	//Ενημερώνει το text
	public void updateText(int i){
		if (!survival)
			GetComponent<Text> ().text = "WAVE:" + i + "/" + LevelHandler.GetSelectedWave () [0].Count.ToString ();
		else
			GetComponent<Text> ().text = "WAVE:" + i;
	}
}
