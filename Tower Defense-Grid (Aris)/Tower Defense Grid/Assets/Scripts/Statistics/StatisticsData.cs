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
		//ΨΑΞΕ ΓΙΑ ΑΡΧΕΙΟ
		string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\Saves";
		filePath = directoryPath + "\\statistics.stat";

		//αρχικοποίηση λιστων
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
			AssistantClass acla = new AssistantClass();
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
		string line;
		try 
		{
			AssistantClass acla = new AssistantClass();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Open);
			acla = (AssistantClass)formatter.Deserialize(stream);
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
		set{ 
			endScore += value;
			int thisScore = value;
			int diff = GameData.Difficulty;
			if (thisScore > highscores [diff,0]) {
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

	public static void SetHighscores(int[,] h){
		highscores = h;
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
}

[Serializable]
public class AssistantClass{

	private int numberOfGames = 0;
	private int[,] highscores = new int[StatisticsData.MaxValueOfDifficulty,StatisticsData.NumberOfHighscores]; 
	/*private int money = 0;
	private int lives = 0;
	private int score = 0;
	private List<int> killist = new List<int> ();
	private List<int> finishList = new List<int> ();
	private List<int> sellTowers = new List<int> ();//να το φτιαξω
	private List<int> totalTowers = new List<int> ();*/
	private int negativeScore = 0, positiveScore = 0;
	private int endScore = 0;
	private int totalMoneys = 0,usedMoneys = 0;
	private int hours = 0,minutes = 0,seconds = 0;

	public AssistantClass(){

	}

	public void TransferDataFromStatistics(){
		numberOfGames = StatisticsData.NumbersOfGames;
		highscores = StatisticsData.HighScores;
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
		StatisticsData.SetHighscores(highscores);
		StatisticsData.NegativeScore = negativeScore;
		StatisticsData.PositiveScore = positiveScore;
		StatisticsData.EndScore = endScore;
		StatisticsData.TotalMoneys = totalMoneys;
		StatisticsData.UsedMoneys = usedMoneys;
		StatisticsData.Hours = hours;
		StatisticsData.Minutes = minutes;
		StatisticsData.Seconds = seconds;
	}

	public void Reset(){

	}
}
