using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatisticsMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FillGrid();
	}
	
	public void FillGrid(){
		GameObject text = (GameObject)Resources.Load("Prefabs/UI/StatisticsText",typeof(GameObject));
		GameObject Grid = GameObject.Find("Grid");

		GameObject newTextFrame = Instantiate (text,new Vector3(0,0,0),Quaternion.identity);
		newTextFrame.transform.Find("TextTitle").GetComponent<Text>().text = "Score";
		newTextFrame.transform.Find ("TextData").GetComponent<Text> ().text = GetComponent<Player> ().Score.ToString();
		newTextFrame.transform.SetParent (Grid.transform);
		newTextFrame.name = "TextFrame1";

		/*for(int i=0;i<num;i++){
			GameObject newbutton = Instantiate(button,new Vector3(0,0,0),Quaternion.identity);
			newbutton.transform.Find("Text").GetComponent<Text>().text = "TRACK" + (i+1);
			newbutton.transform.SetParent(Grid.transform);
			newbutton.name = "Track " + (i+1) + " Button";
			print(i);
			int par = i+1;
			newbutton.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GridManager").GetComponent<LevelSelector>().SelectLevel(par));
			newbutton.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GridManager").GetComponent<LevelSelector>().Survival(true));
			LevelHandler.IsSurvival = true;
		}

		string[] customlevels = LevelHandler.ReadCustomLevels();

		for(int i=0;i<customlevels.Length;i++){
			GameObject newbutton = Instantiate(button,new Vector3(0,0,0),Quaternion.identity);
			newbutton.transform.Find("Text").GetComponent<Text>().text = System.IO.Path.GetFileNameWithoutExtension(customlevels[i]).ToUpper();
			newbutton.transform.SetParent(Grid.transform);
			string path = customlevels[i];
			newbutton.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GridManager").GetComponent<LevelSelector>().SelectCustom(path));
		}*/
	}
}
