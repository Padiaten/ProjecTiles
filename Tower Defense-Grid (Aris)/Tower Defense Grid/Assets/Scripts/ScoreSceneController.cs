using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Διαχειρίζεται την οθόνη με τα highscores
public class ScoreSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowScore ();
	}

	//Τυπώνει στα αντίστοιχα frames τις αντίστοιχες τιμές
	public void ShowScore(){
		string numScore = "", numDif = "";
		for(int i = 0; i<3; i++){
			numDif = (i + 1).ToString ();
			for (int j = 0; j < 3; j++) {
				numScore = (j+1).ToString();
				GameObject.Find ("Score"+numScore+"_"+numDif).GetComponent<Text>().text = StatisticsData.HighScores[i,(2-j)].ToString();
			}
		}
	}

	//Καλείται όταν πατηθέι το κουμπι για τον μηδενισμό των highscores 
	public void Reset(){
		StatisticsData.ResetHighscores ();//τα μηδενίζει
		ShowScore ();//τα ξαναεμφανίζει αλλά τώρα πλέον έχουν μηδενικές τιμες
	}
}
