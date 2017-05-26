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
	private GameObject buttonPerGame;
	private GameObject newButton;
	private int colorPanelCount = 0;
	private int lengthEnemiesList,lengthTowersList;
	private UnityEngine.Object[] enemiesArray;
	private UnityEngine.Object[] towersArray;
	private bool mainStat;
	private int frameNumber = 0;
	private List<GameObject> allFrames = new List<GameObject> ();
	private bool perGame = false;

	// Use this for initialization
	public void ShowStatistics(bool mainStatistics) {
		//mainStatistics: τα στατιστικά όλου του παιχνιδιου
		mainStat = mainStatistics;
		Grid = GameObject.Find("Grid");
		buttonPerGame = GameObject.Find ("PerGame");
		text = (GameObject)Resources.Load("Prefabs/UI/StatisticsText",typeof(GameObject));
		button = (GameObject)Resources.Load("Prefabs/UI/ButtonMoreOrLess",typeof(GameObject));
		enemiesArray = Resources.LoadAll ("Prefabs/Enemies", typeof(GameObject));
		lengthEnemiesList = enemiesArray.Length;
		towersArray = Resources.LoadAll ("Prefabs/Towers", typeof(GameObject));
		lengthTowersList = towersArray.Length;
		if(mainStat){
			FillGridMainStat (false);
		}else{
			if (GameObject.Find ("TextFrame0")) {
				//αν υπαρχουν ηδη μην κανεις τιποτα
			} else {
				FillGrid ();
			}
		}
	}

	public void Reset(){
		StatisticsData.ResetStatistics ();
		int count = allFrames.Count;
		for (int i = 0; i < count; i++) {
			Destroy (allFrames[i]);
		}
		frameNumber = 0;
		FillGridMainStat (perGame);
	}

	public void PerGame(){
		perGame = !perGame;
		int count = allFrames.Count;
		for (int i = 0; i < count; i++) {
			Destroy (allFrames[i]);
		}
		frameNumber = 0;
		if (perGame)
			buttonPerGame.GetComponentInChildren<Text>().text = "TOTAL";
		else
			buttonPerGame.GetComponentInChildren<Text>().text = "PER GAME";
		FillGridMainStat (perGame);
	}

	public void FillGridMainStat(bool perGame)
	{
		float divisor = 1f;
		if (perGame) {
			divisor = (float)StatisticsData.NumbersOfGames;
			if (divisor <= 0f)
				divisor = 1f;
		}
		int text;
		CreateTextFrame ("Number of games",StatisticsData.NumbersOfGames.ToString(),1);
		CreateTextFrameTime (StatisticsData.Hours,StatisticsData.Minutes,StatisticsData.Seconds,"Total game time");
		CreateTextFrame ("Wins / Loses",StatisticsData.Wins+" / "+StatisticsData.Loses,1);
		text = Mathf.RoundToInt ((StatisticsData.Lives / divisor));
		if (perGame) {
			CreateTextFrame ("Lives lost",text.ToString(),1);
			text = Mathf.RoundToInt ((StatisticsData.EndScore / divisor));
			CreateTextFrame ("End score",text.ToString(),1);
			text = Mathf.RoundToInt ((StatisticsData.Score / divisor));
			CreateTextFrame ("Score",text.ToString(),1);
			text = Mathf.RoundToInt ((StatisticsData.PositiveScore / divisor));
			CreateTextFrame ("-Positive score",text.ToString(),4);
			text = Mathf.RoundToInt ((StatisticsData.NegativeScore / divisor));
			CreateTextFrame ("-Negative score",text.ToString(),4);
		}
		text = Mathf.RoundToInt ((StatisticsData.Waves / divisor));
		CreateTextFrame ("Waves played",text.ToString(),1);
		text = Mathf.RoundToInt ((StatisticsData.TotalMoneys / divisor));
		CreateTextFrame ("Total money",text.ToString(),1);
		text = Mathf.RoundToInt ((StatisticsData.UsedMoneys / divisor));
		CreateTextFrame ("Used money",text.ToString(),1);
		CreateTextFrameEnemies (StatisticsData.Killist,StatisticsData.FinishList,divisor);
		CreateTextFrameTowers (StatisticsData.TotalTowers,StatisticsData.SellTowers,divisor);
	}
	
	public void FillGrid(){
		CreateTextFrameTime (GetComponent<Player> ().Hours,GetComponent<Player> ().Minutes,GetComponent<Player> ().Seconds,"Time");
		CreateTextFrame ("End score",GetComponent<Player> ().EndScore.ToString(),1);
		CreateTextFrame ("Score",GetComponent<Player> ().Score.ToString(),1);
		CreateTextFrame ("-Positive Score",GetComponent<Player>().PositiveScore.ToString(),4);
		CreateTextFrame ("-Negative Score",GetComponent<Player>().NegativeScore.ToString(),4);
		CreateTextFrame ("Lives/Starting Lives",GetComponent<Player>().Lives.ToString()+"/"+LevelHandler.SelectedLives.ToString(),1);
		CreateTextFrame ("Total money",GetComponent<Player>().TotalMoneys.ToString(),1);
		CreateTextFrame ("-Used money",GetComponent<Player>().UsedMoneys.ToString(),4);
		CreateTextFrame ("-Remaining money",GetComponent<Player>().Money.ToString(),4);
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
		CreateTextFrameEnemies (GetComponent<Player> ().Killist,GetComponent<Player> ().FinishList,1);
		CreateTextFrameTowers (GetComponent<Player> ().TotalTowers,GetComponent<Player> ().SellTowers,1);
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

	public void CreateTextFrameTowers(List<int> totalList,List<int> sellList,float divisor)
	{
		float sum = CountTotalOfList (totalList);
		int percentage;
		int text;

		sum = Mathf.RoundToInt((sum / divisor));
		CreateTextFrame ("Towers built",sum.ToString(),1);
		for (int i = 0; i < lengthTowersList; i++) {
			if (sum != 0)
				percentage = Mathf.RoundToInt ((((totalList [i]/divisor) / sum)* 100));
			else
				percentage = 0;
			text = Mathf.RoundToInt ((totalList [i] / divisor));
			if(perGame)
				CreateTextFrame ("-"+towersArray[i].name,percentage.ToString()+"%",4);
			else
				CreateTextFrame ("-"+towersArray[i].name,text+" - "+percentage.ToString()+"%",4);
		}

		sum = CountTotalOfList (sellList);
		sum = Mathf.RoundToInt((sum / divisor));
		CreateTextFrame ("Towers sold",sum.ToString(),1);
		for (int i = 0; i < lengthTowersList; i++) {
			if (sum != 0)
				percentage = Mathf.RoundToInt ((((sellList [i]/divisor) / sum) * 100));
			else
				percentage = 0;
			text = Mathf.RoundToInt ((sellList [i] / divisor));
			if(perGame)
				CreateTextFrame ("-"+towersArray[i].name,percentage.ToString()+"%",4);
			else
				CreateTextFrame ("-"+towersArray[i].name,text+" - "+percentage.ToString()+"%",4);
		}
	}

	public void CreateTextFrameEnemies(List<int> killist,List<int> finishlist,float divisor)
	{ 
		int percentage,text;
		float sum;
		float sumOfKills = CountTotalOfList (killist);
		float sumOfFinish = CountTotalOfList (finishlist);
		float totalEnemies = sumOfKills + sumOfFinish;

		totalEnemies = Mathf.RoundToInt((totalEnemies/divisor));
		CreateTextFrame ("Total enemies spawned",totalEnemies.ToString(),1);
		for (int i = 0; i < lengthEnemiesList; i++) {
			sum = killist [i] + finishlist [i];
			if (totalEnemies != 0)
				percentage = Mathf.RoundToInt ((((sum / divisor) / totalEnemies) * 100));
			else
				percentage = 0;
			text = Mathf.RoundToInt ((sum / divisor));
			if(perGame)
				CreateTextFrame ("-"+enemiesArray[i].name,percentage.ToString()+"%",4);
			else
				CreateTextFrame ("-"+enemiesArray[i].name,text.ToString()+" - "+percentage.ToString()+"%",4);
		}

		CreateTextFrameEnemy (sumOfKills,totalEnemies,killist,"Enemies killed",4,lengthEnemiesList,divisor);
		CreateTextFrameEnemy (sumOfFinish,totalEnemies,finishlist,"Enemies not killed",4,lengthEnemiesList,divisor);
	}

	public void CreateTextFrameEnemy(float sumOfList,float total,List<int> list,string title,int startSpaces,int size,float divisor)
	{
		//startSpaces: απο τι εσοχη θα ξεκιναει
		int percentage,text;
		if (total != 0)
			percentage = Mathf.RoundToInt ((((sumOfList / divisor) / total) * 100));
		else
			percentage = 0;
		sumOfList = Mathf.RoundToInt ((sumOfList / divisor));
		if(perGame)
			CreateTextFrame (title,percentage.ToString()+"%",startSpaces);
		else
			CreateTextFrame (title,sumOfList.ToString()+" - "+percentage.ToString()+"%",startSpaces);
		
		for (int i = 0; i < size; i++) {
			if (sumOfList != 0)
				percentage = Mathf.RoundToInt ((((list [i] / divisor)/ sumOfList) * 100));
			else
				percentage = 0;
			text = Mathf.RoundToInt ((list[i] / divisor));
			if(perGame)
				CreateTextFrame ("-"+enemiesArray[i].name,percentage.ToString()+"%",(startSpaces+3));
			else
				CreateTextFrame ("-"+enemiesArray[i].name,text.ToString()+" - "+percentage.ToString()+"%",(startSpaces+3));
		}
	}

	public void CreateTextFrame (string textTitle,string textData,int numOfspaces)
	{
		//NumOfSpaces: ουσιαστικα δηλωνει πόσο μεσα θα βρισκεται(?).κατωτατο καλο ειναι να μπαινει το 1 και οχι το 0
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
		allFrames.Add (newTextFrame);
		colorPanelCount++;
		frameNumber++;
	} 

	public float CountTotalOfList(List<int> list)
	{
		float total = 0f;
		for (int i = 0; i < list.Count; i++) {
			total += list[i];
		}
		return total;
	}
}