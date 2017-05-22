﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string numScore = "", numDif = "";
		for(int i = 0; i<3; i++){
			numDif = (i + 1).ToString ();
			for (int j = 0; j < 3; j++) {
				//Score1_1
				numScore = (j+1).ToString();
				GameObject.Find ("Score"+numScore+"_"+numDif).GetComponent<Text>().text = StatisticsData.HighScores[i,(2-j)].ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}