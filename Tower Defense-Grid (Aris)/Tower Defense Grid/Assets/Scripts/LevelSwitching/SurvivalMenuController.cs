using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SurvivalMenuController : MonoBehaviour {

	void Start(){
		FillGrid();
	}

	public void FillGrid(){
		GameObject button = (GameObject)Resources.Load("Prefabs/UI/SurvivalButtonPrefab",typeof(GameObject));
		GameObject Grid = GameObject.Find("Grid");

		int num = LevelHandler.NumbersOfTracks;
		for(int i=0;i<num;i++){
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
		}
	}
}
