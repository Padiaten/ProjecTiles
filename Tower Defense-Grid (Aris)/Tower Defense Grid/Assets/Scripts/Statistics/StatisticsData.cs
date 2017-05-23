using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public static class StatisticsData {

	private static int maxValueOfDifficulty = 3;//π;όσες διαφορετικες διακριτες τιμε μπορει να παρει
	private static int numOfHighscores = 3;
	private static int lengthTowers;
	private static int lengthEnemies;
	private static bool isHighscore = false;

	//FILE 
	private static string filePath;

	private static int numberOfGames = 0;//αυξανεται όπου υπάρχει εντολή "SceneManager.LoadScene ("MainGame");"
	private static int[,] highscores = new int[maxValueOfDifficulty,numOfHighscores]; 

	private static int wins = 0,loses = 0;
	private static int lives = 0;//xamenes zoes
	private static int score = 0;
	private static int waves = 0;

	private static List<int> killist = new List<int> ();
	private static List<int> finishList = new List<int> ();
	private static List<int> sellTowers = new List<int> ();//να το φτιαξω
	private static List<int> totalTowers = new List<int> ();

	private static int negativeScore = 0, positiveScore = 0;
	private static int endScore = 0;
	private static int totalMoneys = 0,usedMoneys = 0;
	private static int hours = 0,minutes = 0,seconds = 0;


	public static void Initialize () {

		Debug.Log ("INITIALIZE");

		string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\Saves";
		filePath = directoryPath + "\\statistics.stat";

		//αρχικοποίηση λιστων
		lengthEnemies = Resources.LoadAll ("Prefabs/Enemies", typeof(GameObject)).Length;
		for (int i = 0; i < lengthEnemies; i++) {
			killist.Add(0);
			finishList.Add(0);
		}
		lengthTowers = Resources.LoadAll ("Prefabs/Towers",typeof(GameObject)).Length;
		for (int i = 0; i < lengthTowers; i++) {
			totalTowers.Add (0);
			sellTowers.Add (0);
		}

		//ψαξε τον φακελο
		if (System.IO.Directory.Exists(directoryPath)) {//τον βρηκες
			//υπαρχει το αρχειο;
			if (System.IO.File.Exists (filePath)) {
				//αν ειναι αδειο μην διαβασεις
				Stream stream = new FileStream (filePath,FileMode.Open);
				int b = stream.ReadByte ();
				stream.Close ();
				if (b != -1) {
					TransferDataFromFile ();
				}
			} else {
				System.IO.File.Create (filePath);
			}
		} else {//δεν τον βρήκες
			//δημιουργησε φακελο κι αρχειο και βάλε στις τιμες 0
			System.IO.Directory.CreateDirectory(directoryPath);
			System.IO.File.Create (filePath);
		}
	}

	public static void Save()//να αποθηκεύονται κατα την εξοδο
	{
		Debug.Log ("SAVE");
		try {
			AssistantClassStatistics acla = new AssistantClassStatistics();
			acla.TransferDataFromStatistics();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Truncate);
			formatter.Serialize (stream,acla);
			stream.Close ();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	public static void TransferDataFromFile()
	{
		Debug.Log ("TRANSFER");

		try 
		{
			AssistantClassStatistics acla = new AssistantClassStatistics();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Open);
			acla = (AssistantClassStatistics)formatter.Deserialize(stream);
			stream.Close ();
			acla.Load();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	public static void ResetStatistics(){
		Debug.Log ("RESET STAT");

		try {
			AssistantClassStatistics acla = new AssistantClassStatistics();
			acla.ResetStatistics();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Truncate);
			formatter.Serialize (stream,acla);
			stream.Close ();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	public static void ResetHighscores(){
		Debug.Log ("RESET HIGH");

		try {
			AssistantClassStatistics acla = new AssistantClassStatistics();
			acla.ResetHighscores();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Truncate);
			formatter.Serialize (stream,acla);
			stream.Close ();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	public static int Wins{
		get{ return wins; }
		set{ wins = value; }
	}

	public static int Loses{
		get{ return loses; }
		set{ loses = value; }
	}

	public static int Lives{
		get{ return lives; }
		set{ lives = value; }
	}

	public static List<int> Killist{
		get{ return killist; }
		set{ killist = value; }
	}

	public static List<int> FinishList{
		get{ return finishList; }
		set{ finishList = value; }
	}

	public static List<int> TotalTowers{
		get{ return totalTowers; }
		set{ totalTowers = value; }
	}

	public static List<int> SellTowers{
		get{ return sellTowers; }
		set{ sellTowers = value; }
	}

	public static int Waves{
		get{ return waves; }
		set{ waves = value; }
	}

	public static int[,] HighScores{
		get{ return highscores; }
		set{ highscores = value;}
	}

	public static int NumbersOfGames{
		get{ return numberOfGames; }
		set{ numberOfGames = value; }
	}

	public static int EndScore{//προσοχη στην χρηση της
		get{ return endScore;}
		set{ endScore = value; }
	}

	public static int SetEndScoreAndHighscores{
		set{ 
			endScore += value;
			int thisScore = value;
			int diff = GameData.Difficulty;
			isHighscore = false;
			if (thisScore > highscores [diff,0]) {
				isHighscore = true;
				highscores [diff,0] = thisScore;
				int[] a = new int[NumberOfHighscores];
				for (int i = 0; i < NumberOfHighscores; i++) {
					a [i] = highscores [diff, i];
				} 
				Array.Sort (a);//με αύξουσα {0,1,2}
				for (int i = 0; i < NumberOfHighscores; i++) {
					highscores [diff, i] = a[i];
				}
				for (int i = 0; i < 3; i++) {
					Debug.Log(highscores[diff,i]+" high");
				}
			} 
		}
	}

	public static int NegativeScore{
		get{ return negativeScore; }
		set{ negativeScore = value; }
	}

	public static int PositiveScore{
		get{ return positiveScore; }
		set{ positiveScore = value; }
	}

	public static int Score{
		get{ return score; }
		set{ score = value; }
	}

	public static int TotalMoneys{
		get{ return totalMoneys; }
		set{ totalMoneys = value; }
	}

	public static int UsedMoneys{
		get{ return usedMoneys; }
		set{ usedMoneys = value; }
	}

	public static int Hours{
		get{ return hours; }
		set{ hours = value; }
	}

	public static int Minutes{
		get{ return minutes; }
		set{ 
			minutes = value; 
			if (minutes > 60) {
				minutes -= 60;
				hours++;
			}
		}
	}

	public static int Seconds{
		get{ return seconds; }
		set{ 
			seconds = value; 
			if (seconds > 60) {
				seconds -= 60;
				minutes++;
				if (minutes > 60) {
					minutes -= 60;
					hours++;
				}
			}
		}
	}

	public static int MaxValueOfDifficulty{
		get{ return maxValueOfDifficulty; }
	}

	public static int NumberOfHighscores{
		get{ return numOfHighscores; }
	}

	public static int LengthEnemies{
		get{ return lengthEnemies; }
	}

	public static int LengthTowers{
		get{ return lengthTowers; }
	}

	public static bool IsHighscore{
		get{ return isHighscore; }
	}
}

[Serializable]
public class AssistantClassStatistics{

	private int numberOfGames = 0;
	private int[,] highscores = new int[StatisticsData.MaxValueOfDifficulty,StatisticsData.NumberOfHighscores]; 
	private int wins = 0,loses = 0;

	private int lives = 0;
	private int score = 0;
	private int waves = 0;

	private List<int> killist = new List<int> ();
	private List<int> finishList = new List<int> ();
	private List<int> sellTowers = new List<int> ();
	private List<int> totalTowers = new List<int> ();

	private int negativeScore = 0, positiveScore = 0;
	private int endScore = 0;
	private int totalMoneys = 0,usedMoneys = 0;
	private int hours = 0,minutes = 0,seconds = 0;

	public AssistantClassStatistics(){
	}

	public void TransferDataFromStatistics(){
		numberOfGames = StatisticsData.NumbersOfGames;
		highscores = StatisticsData.HighScores;
		wins = StatisticsData.Wins;
		loses = StatisticsData.Loses;
		lives = StatisticsData.Lives;
		score = StatisticsData.Score;
		waves = StatisticsData.Waves;
		killist = StatisticsData.Killist;
		finishList = StatisticsData.FinishList;
		sellTowers = StatisticsData.SellTowers;
		totalTowers = StatisticsData.TotalTowers;
		negativeScore = StatisticsData.NegativeScore;
		positiveScore = StatisticsData.PositiveScore;
		endScore = StatisticsData.EndScore;
		totalMoneys = StatisticsData.TotalMoneys;
		usedMoneys = StatisticsData.UsedMoneys;
		hours = StatisticsData.Hours;
		minutes = StatisticsData.Minutes;
		seconds = StatisticsData.Seconds;
	}

	public void Load(){
		StatisticsData.NumbersOfGames = numberOfGames;
		StatisticsData.HighScores = highscores;
		StatisticsData.Wins = wins;
		StatisticsData.Loses = loses;
		StatisticsData.Lives = lives;
		StatisticsData.Score = score;
		StatisticsData.Waves = waves;
		StatisticsData.Killist = killist;
		StatisticsData.FinishList = finishList;
		StatisticsData.SellTowers = sellTowers;
		StatisticsData.TotalTowers = totalTowers;
		StatisticsData.NegativeScore = negativeScore;
		StatisticsData.PositiveScore = positiveScore;
		StatisticsData.EndScore = endScore;
		StatisticsData.TotalMoneys = totalMoneys;
		StatisticsData.UsedMoneys = usedMoneys;
		StatisticsData.Hours = hours;
		StatisticsData.Minutes = minutes;
		StatisticsData.Seconds = seconds;
	}

	public void ResetStatistics(){
		highscores = StatisticsData.HighScores;//απαραιτητο για να μην μηδενιστει και το highscore
		StatisticsData.NumbersOfGames = 0;
		StatisticsData.Wins = 0;
		StatisticsData.Loses = 0;
		StatisticsData.Lives = 0;
		StatisticsData.Score = 0;
		StatisticsData.Waves = 0;
		StatisticsData.NegativeScore = 0;
		StatisticsData.PositiveScore = 0;
		StatisticsData.EndScore = 0;
		StatisticsData.TotalMoneys = 0;
		StatisticsData.UsedMoneys = 0;
		StatisticsData.Hours = 0;
		StatisticsData.Minutes = 0;
		StatisticsData.Seconds = 0;

		int count = StatisticsData.LengthEnemies;
		for (int i = 0; i < count; i++) {
			killist.Add(0);
			finishList.Add(0);
		}
		count = StatisticsData.LengthTowers;
		for (int i = 0; i < count; i++) {
			totalTowers.Add (0);
			sellTowers.Add (0);
		}
		Load ();
	}
		
	public void ResetHighscores(){
		
		int iCount = StatisticsData.MaxValueOfDifficulty;
		int jCount = StatisticsData.NumberOfHighscores;
		for(int i=0; i<iCount ; i++){
			for(int j=0; j<jCount; j++){
				highscores [i, j] = 0;
			}
		}
		StatisticsData.HighScores = highscores;
	}
}
