using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextController : MonoBehaviour {

	void Start(){
		GetComponent<Text>().text = "WAVE:" + GameObject.Find("GameFlow").GetComponent<WaveControler>().getWaveIndex().ToString() + "/" + LevelHandler.GetSelectedWave().Count.ToString();
	}

	public void updateText(int i){
		GetComponent<Text>().text = "WAVE:" + i + "/" + LevelHandler.GetSelectedWave().Count.ToString();
	}
}
