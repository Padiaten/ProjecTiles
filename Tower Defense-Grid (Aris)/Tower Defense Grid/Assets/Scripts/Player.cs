﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class Player : MonoBehaviour {

	//PLAYER DATA FOR IN GAME
	private int money;
	private int lives;
	private int score = 0; 
	private int endScore; //score = [(life*100+20*remaining gold)*diff]/(time/10) + Score
	//PLAYER DATA FOR STATISTICS
	private List<int> killist = new List<int> ();
	private List<int> finishList = new List<int> ();
	private List<int> sellTowers = new List<int> ();//να το φτιαξω
	private List<int> totalTowers = new List<int> (); 
	private int negativeScore = 0, positiveScore = 0;
	private int totalMoneys = 0,usedMoneys = 0;
	private Stopwatch chronometer = new Stopwatch();
	private int hours,minutes,seconds;

	// Use this for initialization
	void Start () {
		lives = LevelHandler.SelectedLives;
		money = LevelHandler.SelectedMoneys;

		UpdateHealth();
		UpdateTextGold();
		UpdateScore (0);
		totalMoneys = money;

		int lengthEnemies = Resources.LoadAll ("Prefabs/Enemies", typeof(GameObject)).Length;
		for (int i = 0; i < lengthEnemies; i++) {
			killist.Add(0);
			finishList.Add(0);
		}
		int lengthTowers = Resources.LoadAll ("Prefabs/Towers",typeof(GameObject)).Length;
		for (int i = 0; i < lengthTowers; i++) {
			totalTowers.Add (0);
			sellTowers.Add (0);
		}
	}

	public void TransferDataInStatistics()
	{
		StatisticsData.Hours += hours;
		StatisticsData.Minutes += minutes;
		StatisticsData.Seconds += seconds;
		StatisticsData.EndScore += endScore;
	}

	public void CaclculateEndScore(){
		int timeInSeconds = Mathf.RoundToInt((chronometer.ElapsedMilliseconds)/1000);
		if ((timeInSeconds / 10f) != 0)
			endScore = Mathf.RoundToInt((((lives * 100f + 20f * money)*GameData.Difficulty) / (timeInSeconds / 10f)) + score);
		else
			endScore = score;
		print (timeInSeconds+" seconds");
		print (lives+" lives");
		print (money+" money");
		print (score+" score");
		print (endScore+" endscore");
	}

	public void AddInEnemieList(int id,bool isKill) 
	{
		if (isKill)
			killist [id]++;
		else 
			finishList [id]++;
	}

	public void  UpdateHealth(){
		GameObject.Find ("HealthText").GetComponent<Text> ().text = lives.ToString ();
	}

	public void UpdateGold(int value){
		money += value;
		UpdateTextGold ();
		if (value < 0)
			usedMoneys -= value;
		else if(value > 0)
			totalMoneys += value;
	}

	public void AddInTowerList(int id,bool creation)
	{
		if (creation)
			totalTowers [id]++;
		else
			sellTowers [id]++;

	}

	public void UpdateTextGold()
	{
		GameObject.Find ("GoldText").GetComponent<Text> ().text = money.ToString ();
	}

	public void UpdateScore(int scorePoints)
	{
		score += scorePoints;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = score.ToString ();
		if (scorePoints < 0)
			negativeScore -= scorePoints;
		else if(scorePoints > 0)
			positiveScore += scorePoints;
	}

	public void ControLives()
	{
		if (lives <= 0)
			this.gameObject.GetComponent<FlowController> ().EndGame ();
	}

	//control chronometer
	public void StartChronometer(){
		chronometer.Start ();
	}
	public void StopChronometer(){
		chronometer.Stop ();
	}

	public void EndChronometer()
	{
		chronometer.Stop ();
		System.TimeSpan time = chronometer.Elapsed;
		hours = time.Hours;
		minutes = time.Minutes;
		seconds = time.Seconds;
	}

	//GETTERS
	public int Money{
		get{ return money;}
		set{ money = value;}
	}

	public int Lives{
		get{ return lives;}
		set{ lives = value;}
	}

	public int Score{
		get{ return score; }
		set{ score = value; }
	}

	public int EndScore{
		get{ return endScore; }
		set{ endScore = value; }
	}

	public int NegativeScore{
		get{ return negativeScore; }
	}

	public int PositiveScore{
		get{ return positiveScore; }
	}

	public int TotalMoneys{
		get{ return totalMoneys; }
	}

	public int UsedMoneys{
		get{ return usedMoneys; }
	}

	public List<int> Killist{
		get{ return killist; }
	}

	public List<int> FinishList{
		get{ return finishList; }
	}

	public List<int> TotalTowers{
		get{ return totalTowers; }
	}

	public List<int> SellTowers{
		get{ return sellTowers; }
	}

	public int Hours{
		get{ return hours; }
	}

	public int Minutes{
		get{ return minutes; }
	}

	public int Seconds{
		get{ return seconds; }
	}
}
