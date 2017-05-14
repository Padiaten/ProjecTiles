using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public void LoadGame(string sel_schene) {
		Application.LoadLevel (sel_schene);
}
	public void QuitGame(){
		Application.Quit ();
	}
}