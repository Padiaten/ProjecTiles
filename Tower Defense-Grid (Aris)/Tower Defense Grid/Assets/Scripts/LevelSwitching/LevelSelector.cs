using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public void SelectLevel(int i){
		LevelHandler.PickLevel(i);
	}

	public void Survival(bool s)
	{
		LevelHandler.IsSurvival = s;
		SceneManager.LoadScene ("MainGame");
	}

	public void SelectCustom(string path){
		LevelHandler.ReadCustom(path);
		SceneManager.LoadScene ("MainGame");
	}
}
