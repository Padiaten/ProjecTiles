using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextController : MonoBehaviour {

	private bool survival = LevelHandler.IsSurvival;

	void Start(){
		if (!survival)
			GetComponent<Text> ().text = "WAVE:" + GameObject.Find ("GameFlow").GetComponent<WaveControler> ().WavesIndex.ToString () + "/" + LevelHandler.GetSelectedWave () [0].Count.ToString ();
		else
			GetComponent<Text> ().text = "WAVE:" + GameObject.Find ("GameFlow").GetComponent<WaveControler> ().WavesIndex.ToString ();
	}

	public void updateText(int i){
		if (!survival)
			GetComponent<Text> ().text = "WAVE:" + i + "/" + LevelHandler.GetSelectedWave () [0].Count.ToString ();
		else
			GetComponent<Text> ().text = "WAVE:" + i;
	}
}
