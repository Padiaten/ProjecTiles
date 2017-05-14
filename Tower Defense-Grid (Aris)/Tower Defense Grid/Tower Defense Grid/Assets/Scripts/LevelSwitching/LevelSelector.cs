using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	public void SelectLevel(int i){
		LevelHandler.PickLevel(i);
		Application.LoadLevel("MainGame");
	}
}
