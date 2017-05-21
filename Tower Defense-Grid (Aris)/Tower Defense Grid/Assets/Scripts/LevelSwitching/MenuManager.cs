using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour {

	public void LoadGame(string sel_schene) {
		SceneManager.LoadScene (sel_schene);
	}

	public void QuitGame(){
		//StatisticsData.Save();
		print ("Quit");
		Application.Quit (); 
	}
}