using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public GameObject infomessage;
	int progress,sel_level;

	//Sets which level the player can play on story mode
	void Start(){


		if(!LevelHandler.IsSurvival){
			progress = GameData.Progress;
			GameObject l2 = GameObject.Find("Level 2 Button");
			GameObject l3 = GameObject.Find("Level 3 Button");

			if(progress == 1){

				l2.GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);
				l2.transform.Find("Image").GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);
				l3.GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);
				l3.transform.Find("Image").GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);


			}else if(progress == 2){
				l3.GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);
				l3.transform.Find("Image").GetComponent<Image>().color = new Color(100/255f,100/255f,100/255f,1);
			}
		}
	}

	//Calls PickLevel on LevelHandler which loads correct map
	public void SelectLevel(int i){
		
			LevelHandler.PickLevel(i);
			sel_level = i;
	}

	//Starts survival mode
	public void Survival(bool s)
	{
		
		LevelHandler.IsSurvival = s;
		if(s == true || progress >= sel_level){
			SceneManager.LoadScene ("MainGame");
			StatisticsData.NumbersOfGames++;
		}else{
			infomessage.GetComponent<DisplayLockedLevelMessage>().disp();
		}

}


	//Calls ReadCustom which loads custom levels
	public void SelectCustom(string path){
		LevelHandler.ReadCustom(path);
		SceneManager.LoadScene ("MainGame");
		StatisticsData.NumbersOfGames++;
	}		
}