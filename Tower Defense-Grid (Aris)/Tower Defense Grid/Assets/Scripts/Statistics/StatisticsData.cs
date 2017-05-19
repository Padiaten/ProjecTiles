using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class StatisticsData {

	//FILE 
	private static string filePath;

	private static int numberOfGames = 0;//αυξανεται όπου υπάρχει εντολή "SceneManager.LoadScene ("MainGame");"
	/*private int money = 0;
	private int lives = 0;
	private int score = 0;
	private List<int> killist = new List<int> ();
	private List<int> finishList = new List<int> ();
	private List<int> sellTowers = new List<int> ();//να το φτιαξω
	private List<int> totalTowers = new List<int> ();*/
	private static int negativeScore = 0, positiveScore = 0;
	private static int endScore = 0;
	private static int totalMoneys = 0,usedMoneys = 0;
	private static int hours = 0,minutes = 0,seconds = 0;

	public static void Initialize () {
		//ΨΑΞΕ ΓΙΑ ΑΡΧΕΙΟ
		string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\StatisticsData";
		filePath = directoryPath + "\\statistics.stat";

		//ψαξε τον φακελο
		if (System.IO.Directory.Exists(directoryPath)) {//τον βρηκες
			//υπαρχει το αρχειο;
			if (System.IO.File.Exists (filePath)) {
				StreamReader sr = new StreamReader(filePath);
				string line = sr.ReadLine ();
				sr.Close ();
				if(line != null)//αν το αρχείο δεν έιναι κενο
					TransferDataFromFile ();//μετεφερε τα δεδομενα στις μεταβλητες
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
		try {

			//Pass the filepath and filename to the StreamWriter Constructor
			StreamWriter sw = new StreamWriter(filePath);

			sw.WriteLine(numberOfGames);
			sw.WriteLine(hours);
			sw.WriteLine(minutes);
			sw.WriteLine(seconds);
			sw.WriteLine(endScore);
			/*sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();*/


			//Close the file
			sw.Close();
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
		string line;
		try 
		{
			//Pass the file path and file name to the StreamReader constructor
			StreamReader sr = new StreamReader(filePath);

			numberOfGames = int.Parse(sr.ReadLine());
			hours = int.Parse(sr.ReadLine());
			minutes = int.Parse(sr.ReadLine());
			seconds = int.Parse(sr.ReadLine());
			endScore = int.Parse(sr.ReadLine());
			//int.Parse(sr.ReadLine()) warning int,float,string
			//close the file
			sr.Close();
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

	public static int NumbersOfGames{
		get{ return numberOfGames; }
		set{ numberOfGames = value; }
	}

	public static int EndScore{
		get{ return endScore; }
		set{ endScore = value; }
	}

	public static int NegativeScore{
		get{ return negativeScore; }
	}

	public static int PositiveScore{
		get{ return positiveScore; }
	}

	public static int TotalMoneys{
		get{ return totalMoneys; }
	}

	public static int UsedMoneys{
		get{ return usedMoneys; }
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
}
