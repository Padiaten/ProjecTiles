using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	/*void Start(){
	}*/

	public void LoadGame(string sel_schene) {
		SceneManager.LoadScene (sel_schene);
}
	public void QuitGame(){
		Application.Quit (); 
	}
}