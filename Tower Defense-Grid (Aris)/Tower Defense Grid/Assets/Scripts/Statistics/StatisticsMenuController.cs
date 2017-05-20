using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class StatisticsMenuController : MonoBehaviour {

	private static int StartDestroyFrame = 9;
	private static int EndDestroyFrame = 40;
	private GameObject Grid;
	private GameObject text;
	private GameObject newTextFrame;
	private GameObject button;
	GameObject newButton;
	private int colorPanelCount = 0;
	private int lengthEnemiesList,lengthTowersList;
	private UnityEngine.Object[] enemiesArray;
	private UnityEngine.Object[] towersArray;
	private bool mainStat;
	private int frameNumber = 0;

	// Use this for initialization
	public void ShowStatistics(bool mainStatistics) {
		//mainStatistics: τα στατιστικά όλου του παιχνιδιου
		mainStat = mainStatistics;
		Grid = GameObject.Find("Grid");
		text = (GameObject)Resources.Load("Prefabs/UI/StatisticsText",typeof(GameObject));
		button = (GameObject)Resources.Load("Prefabs/UI/ButtonMoreOrLess",typeof(GameObject));
		if(mainStat){
			FillGridMainSat ();
		}else{
			if (GameObject.Find ("TextFrame0")) {

			} else {
				enemiesArray = Resources.LoadAll ("Prefabs/Enemies", typeof(GameObject));
				lengthEnemiesList = enemiesArray.Length;
				towersArray = Resources.LoadAll ("Prefabs/Towers", typeof(GameObject));
				lengthTowersList = towersArray.Length;
				FillGrid ();
			}
		}
	}

	public void FillGridMainSat()
	{
		CreateTextFrame ("Number of games",StatisticsData.NumbersOfGames.ToString(),1);
		CreateTextFrameTime (StatisticsData.Hours,StatisticsData.Minutes,StatisticsData.Seconds,"Total time");
	}
	
	public void FillGrid(){
		CreateTextFrameTime (GetComponent<Player> ().Hours,GetComponent<Player> ().Minutes,GetComponent<Player> ().Seconds,"Time");
		CreateTextFrame ("End score",GetComponent<Player> ().EndScore.ToString(),1);
		CreateTextFrame ("Score",GetComponent<Player> ().Score.ToString(),1);
		CreateTextFrame ("-Positive Score",GetComponent<Player>().PositiveScore.ToString(),4);
		CreateTextFrame ("-Negative Score",GetComponent<Player>().NegativeScore.ToString(),4);
		CreateTextFrame ("Lives/StartLives",GetComponent<Player>().Lives.ToString()+"/"+LevelHandler.SelectedLives.ToString(),1);
		CreateTextFrame ("Total moneys",GetComponent<Player>().TotalMoneys.ToString(),1);
		CreateTextFrame ("-Used moneys",GetComponent<Player>().UsedMoneys.ToString(),4);
		CreateTextFrame ("-Remaining moneys",GetComponent<Player>().Money.ToString(),4);
		//CreateTextFrameEnemies ();
		//CreateTextFrameTowers ();
		CreateButton ("MORE > >",true);
	}

	public void CreateButton(string nameButton,bool more){
		newButton = Instantiate (button,new Vector3(0,0,0),Quaternion.identity);
		newButton.transform.Find("TextMoreOrLess").GetComponent<Text>().text = nameButton;
		newButton.transform.SetParent (Grid.transform);
		newButton.name = "ButtonFrame";
		if(more)
			newButton.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameFlow").GetComponent<StatisticsMenuController>().More());
		else
			newButton.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameFlow").GetComponent<StatisticsMenuController>().Less());
	}

	public void More(){
		Destroy (newButton);
		CreateTextFrameEnemies ();
		CreateTextFrameTowers ();
		CreateButton ("< < LESS",false);
	}

	public void Less(){
		Destroy (newButton);
		for (int i = StartDestroyFrame; i <= EndDestroyFrame; i++) {
			Destroy (GameObject.Find("TextFrame"+i));
			frameNumber--;
		} 
		CreateButton ("MORE > >",true);
		GameObject.Find ("Scrollbar").GetComponent<Scrollbar> ().value = 1;
	}

	public void CreateTextFrameTime(int hours,int minutes,int seconds,string title)
	{
		string hoursText,minutesText,secondsText;
		if (hours < 10)
			hoursText = "0" + hours.ToString ();
		else
			hoursText = hours.ToString ();
		
		if (minutes < 10)
			minutesText = "0" + minutes.ToString ();
		else
			minutesText = minutes.ToString ();
		
		if (seconds < 10)
			secondsText = "0" + seconds.ToString ();
		else
			secondsText = seconds.ToString ();
		
		string timeText = hoursText + ":" + minutesText + ":" + secondsText;
		CreateTextFrame (title,timeText,1);
	}

	public void CreateTextFrameTowers()
	{
		List<int> totalTowersList = GetComponent<Player> ().TotalTowers;
		List<int> sellTowersList = GetComponent<Player> ().SellTowers;
		float sum = CountTotalOfList (lengthTowersList,totalTowersList);
		float percentage;

		CreateTextFrame ("Total towers",sum.ToString(),1);
		for (int i = 0; i < lengthTowersList; i++) {
			if (sum != 0)
				percentage = Mathf.RoundToInt (((totalTowersList [i] / sum) * 100));
			else
				percentage = 0;
			CreateTextFrame ("-"+towersArray[i].name,totalTowersList[i]+" - "+percentage.ToString()+"%",4);
		}

		sum = CountTotalOfList (lengthTowersList, sellTowersList);
		CreateTextFrame ("Sell towers",sum.ToString(),1);
		for (int i = 0; i < lengthTowersList; i++) {
			if (sum != 0)
				percentage = Mathf.RoundToInt (((sellTowersList [i] / sum) * 100));
			else
				percentage = 0;
			CreateTextFrame ("-"+towersArray[i].name,sellTowersList[i]+" - "+percentage.ToString()+"%",4);
		}
	}

	public void CreateTextFrameEnemies()
	{
		List<int> killist = GetComponent<Player> ().Killist;
		List<int> finishlist = GetComponent<Player> ().FinishList;
		float percentage;
		float sum;
		float sumOfKills = CountTotalOfList (lengthEnemiesList, killist);
		float sumOfFinish = CountTotalOfList (lengthEnemiesList, finishlist);
		float totalEnemies = sumOfKills + sumOfFinish;

		CreateTextFrame ("Total enemies",totalEnemies.ToString()+" - 100%",1);
		for (int i = 0; i < lengthEnemiesList; i++) {
			sum = killist [i] + finishlist [i];
			percentage = Mathf.RoundToInt (((sum / totalEnemies)*100));
			CreateTextFrame ("-"+enemiesArray[i].name,sum.ToString()+" - "+percentage.ToString()+"%",4);
		}

		CreateTextFrameEnemy (sumOfKills,totalEnemies,killist,"Kill enemies",4,lengthEnemiesList);
		CreateTextFrameEnemy (sumOfFinish,totalEnemies,finishlist,"Finish enemies",4,lengthEnemiesList);
	}

	public void CreateTextFrameEnemy(float sumOfList,float total,List<int> list,string title,int startSpaces,int size)
	{
		//startSpaces: απο τι εσοχη θα ξεκιναει
		float percentage = Mathf.RoundToInt (((sumOfList/total)*100));
		CreateTextFrame (title,sumOfList.ToString()+" - "+percentage.ToString()+"%",startSpaces);
		for (int i = 0; i < size; i++) {
			if (sumOfList != 0)
				percentage = Mathf.RoundToInt (((list [i] / sumOfList) * 100));
			else
				percentage = 0;
			CreateTextFrame ("-"+enemiesArray[i].name,list[i].ToString()+" - "+percentage.ToString()+"%",(startSpaces+3));
		}
	}

	public void CreateTextFrame (string textTitle,string textData,int numOfspaces)
	{
		//NumOfSpaces: ουσιαστικα δηλωνει πόσο μεσα θα βρισκεται(?).κατωτατο καλο ειναι να μπαινει το 1
		string space = "";
		for (int i = 0; i < numOfspaces; i++) {
			space = space + " ";
		}
		newTextFrame = Instantiate (text,new Vector3(0,0,0),Quaternion.identity);
		newTextFrame.transform.Find("TextTitle").GetComponent<Text>().text = space+textTitle;
		newTextFrame.transform.Find ("TextData").GetComponent<Text> ().text = textData;
		newTextFrame.transform.SetParent (Grid.transform);
		newTextFrame.name = "TextFrame"+frameNumber;
		if (colorPanelCount % 2 == 0)
			newTextFrame.transform.Find ("Panel").GetComponent<Image> ().color = new Color (0.5F, 0.5F, 0.5F, 0.5F);
		else
			newTextFrame.transform.Find ("Panel").GetComponent<Image> ().color = new Color (0.0F, 0.0F, 0.0F, 0.5F);
		colorPanelCount++;
		frameNumber++;
	} 

	public float CountTotalOfList(int count,List<int> list)
	{
		float total = 0f;
		for (int i = 0; i < count; i++) {
			total += list[i];
		}
		return total;
	}
}