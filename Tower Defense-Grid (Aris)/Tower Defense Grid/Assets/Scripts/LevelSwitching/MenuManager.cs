using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	/*void Start(){
		
	}*/

	public void LoadGame(string sel_schene) {
		if (sel_schene.CompareTo ("LevelSelect") == 0)
			LevelHandler.IsSurvival = false;
		SceneManager.LoadScene (sel_schene);
	}

	public void QuitGame(){
		//na to sbiso
		StatisticsData.Save();
		print ("Quit");
		Application.Quit (); 
	}
}