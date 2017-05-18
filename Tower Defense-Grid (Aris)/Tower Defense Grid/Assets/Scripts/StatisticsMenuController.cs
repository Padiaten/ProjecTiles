using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class StatisticsMenuController : MonoBehaviour {

	private GameObject Grid;
	private GameObject text;
	private GameObject newTextFrame;
	private int colorPanelCount = 0;
	private int lengthEnemiesList,lengthTowersList;
	private UnityEngine.Object[] enemiesArray;
	private UnityEngine.Object[] towersArray;

	// Use this for initialization
	void Start () {
		enemiesArray = Resources.LoadAll ("Prefabs/Enemies",typeof(GameObject));
		lengthEnemiesList = enemiesArray.Length;
		towersArray = Resources.LoadAll ("Prefabs/Towers",typeof(GameObject));
		lengthTowersList = towersArray.Length;
		Grid = GameObject.Find("Grid");
		text = (GameObject)Resources.Load("Prefabs/UI/StatisticsText",typeof(GameObject));
		FillGrid();
	}
	
	public void FillGrid(){
		CreateTextFrameTime ();
		CreateTextFrame ("Score",GetComponent<Player> ().Score.ToString(),1);
		CreateTextFrame ("-Positive Score",GetComponent<Player>().PositiveScore.ToString(),4);
		CreateTextFrame ("-Negative Score",GetComponent<Player>().NegativeScore.ToString(),4);
		CreateTextFrame ("Lives/StartLives",GetComponent<Player>().Lives.ToString()+"/"+LevelHandler.SelectedLives.ToString(),1);
		CreateTextFrame ("Total moneys",GetComponent<Player>().TotalMoneys.ToString(),1);
		CreateTextFrame ("-Used moneys",GetComponent<Player>().UsedMoneys.ToString(),4);
		CreateTextFrame ("-Remaining moneys",GetComponent<Player>().Money.ToString(),4);
		CreateTextFrameEnemies ();
		CreateTextFrameTowers ();
	}

	public void CreateTextFrameTime()
	{
		string hours,minutes,seconds;
		if (GetComponent<Player> ().Hours < 10)
			hours = "0" + GetComponent<Player> ().Hours.ToString ();
		else
			hours = GetComponent<Player> ().Hours.ToString ();
		
		if (GetComponent<Player> ().Minutes < 10)
			minutes = "0" + GetComponent<Player> ().Minutes.ToString ();
		else
			minutes = GetComponent<Player> ().Minutes.ToString ();
		
		if (GetComponent<Player> ().Seconds < 10)
			seconds = "0" + GetComponent<Player> ().Seconds.ToString ();
		else
			seconds = GetComponent<Player> ().Seconds.ToString ();
		
		string timeText = hours + ":" + minutes + ":" + seconds;
		CreateTextFrame ("Time",timeText,1);
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
		newTextFrame.name = "TextFrame";
		if (colorPanelCount % 2 == 0)
			newTextFrame.transform.Find ("Panel").GetComponent<Image> ().color = new Color (0.5F, 0.5F, 0.5F, 0.5F);
		else
			newTextFrame.transform.Find ("Panel").GetComponent<Image> ().color = new Color (0.0F, 0.0F, 0.0F, 0.5F);
		colorPanelCount++;
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