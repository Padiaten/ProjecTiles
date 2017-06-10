using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class LevelHandler{

	private static List<List<string>> selected_Level = new List<List<string>>();
	private static List<List<List<string>>> selected_Wave = new List<List<List<string>>> ();
	private static List<List<string>> waves1 = new List<List<string>> ();
	private static List<List<string>> waves2 = new List<List<string>> ();
	private static int selectedLives;
	private static int selectedMoneys;
	private static bool isSurvival= false;
	private static int selected_level;
	private static int numberOfTracks = 6;//οποτε προσθετεις καποια πιστα ενημερωσε και την μεταβλητη

	private static int DimX=10,DimY=10;

	//Holds premade levels,picks one of them
	public static void PickLevel(int i){
		selected_level = i;
		selected_Level.Clear();
		selected_Wave.Clear ();
		waves1.Clear ();
		waves2.Clear ();
		switch(i){
		case 1:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","D","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","R","R","RD","R","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","U","X","D","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","U","L","L","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","U","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","DR","R","R","R","U","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","U","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","U","X","X","X","R","E"});
				selected_Level.Add(new List<string>(){"X","R","R","R","R","U","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X"});
				
				
				waves1.Add (new List<string> (){"0.1-3-0-1.5"});
				waves1.Add (new List<string> (){"0.1-6-0-0.7","1.5-3-1-1","1-2-0-0.3","1-2-1-1","1-3-0-0.7","0.2-3-1-0.7"});
				waves1.Add (new List<string> (){"0.5-5-1-0.7","0.5-2-1-0.3","0.5-8-0-0.4","1-3-2-1.2"});
				waves1.Add (new List<string> (){"0.1-1-0-1","0.3-1-1-1","0.3-1-2-1","1-5-2-0.6","0.5-3-1-0.5","0.3-2-2-0.4","1-1-0-1","0.3-12-2-0.7","1.5-1-0-1"});
				waves1.Add (new List<string> (){"1-5-3-1","0.5-4-2-0.6","0.7-4-1-0.2","1-3-0-0.3","0.4-3-3-0.3","0.5-3-0-0.4"});
				waves1.Add (new List<string> (){"1-1-4-1","1.5-2-0-0.4","0.5-2-1-0.4","0.5-2-0-0.4","0.5-1-3-0.4","0.5-2-3-0.4","0.5-7-1-0.4","0.5-2-4-0.4","0.5-2-2-0.4","0.5-3-2-0.4","0.5-2-3-0.4"});
				waves1.Add (new List<string> (){"1-7-4-0.6","2-4-1-0.3","0.5-6-2-0.5","0.7-3-1-0.5","0.3-2-0-1","0.5-6-3-0.5","0.4-4-4-1","0.3-2-0-0.2","0.3-4-4-0.3"});
				waves1.Add (new List<string> (){"1-4-4-0.5","1-4-3-0.5","1-4-2-0.5","1-10-2-0.5","1-7-4-0.5","0.5-5-1-0.2","0.2-3-0-0.2","2-7-2-0.2"});

				selected_Wave.Add (waves1);

				selectedLives = 10 + GameData.Difficulty * 2;
				selectedMoneys = 125;
			
				break;
			}
		case 2:
			{
				selected_Level.Add(new List<string>(){"X","SD","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","R","R","R","R","R","D","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","D","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","L","LD","L","LR","R","R","RD","R","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","D","X","X","X","X","D","X","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","D","X","X","X","X","D","X","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","R","D","X","D","L","L","X","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","D","X","X","X","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","R","R","R","R","R","R","D","L","L","L","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","R","R","R","R","D","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","E","X"});
				

				waves1.Add (new List<string> (){"1-4-0-0.4","0.6-3-1-0.7","0.8-3-0-0.6","1-2-1-0.6"});
				waves1.Add (new List<string> (){"1-10-0-0.3","0.5-2-1-0.4","1-3-0-0.7","0.7-6-1-0.7","0.3-6-0-0.4","1-3-2-0.8","0.5-3-1-0.5","0.1-3-0-0.1","0.5-2-1-0.4","1-3-2-1"});
				waves1.Add (new List<string> (){"0.3-3-2-0.3","0.3-4-1-0.3","0.2-5-0-0.4","0.4-3-1-0.2","0.3-2-0-0.2","0.5-6-2-0.4","0.2-5-0-1","0.2-5-0-0.4","0.2-3-1-0.3","0.2-3-2-0.3","0.2-3-0-0.3","0.2-5-2-0.3","0.2-4-1-0.3","0.2-4-0-0.3"});
				waves1.Add (new List<string> (){"1-4-1-0.4","0.5-3-1-0.2","0.2-6-0-0.2","1-3-3-0.8","0.3-3-2-0.2","1-5-1-0.4","1-1-3-1","0.2-5-0-0.2","0.2-3-1-0.2","0.35-4-1-0.4","0.5-5-3-0.2","0.2-2-2-0.3","0.2-7-2-0.2"});
				waves1.Add (new List<string> (){"0.3-4-2-0.3","0.15-3-1-0.15","0.15-5-3-0.3","1-10-2-0.15","0.3-3-0-0.3","0.3-3-0-0.2","0.3-4-1-0.7","0.4-4-2-0.3","0.6-4-0-0.3","0.3-1-1-0.3","0.2-3-2-0.35","0.3-7-3-0.3"});
				waves1.Add (new List<string> (){"1-3-3-1","0.5-4-0-0.3","0.2-3-2-0.4","1-3-3-0.2",});
				waves1.Add (new List<string> (){"0.2-3-3-0.2","0.2-2-2-0.2","0.3-4-1-0.15","0.2-3-0-0.15","0.15-6-3-0.2","0.5-7-2-0.2","0.5-4-3-0.15","0.2-5-2-0.2"});
				waves1.Add (new List<string> (){"1-10-1-0.25","0.2-5-3-0.2","1-5-4-0.15","0.11-4-0-0.05","0.1-3-2-0.05","0.4-10-4-0.35","1-4-1-0.15","0.10-3-1-0.25","1-1-4-0.05",});
				waves1.Add (new List<string> (){"1-10-3-0.05","0.3-5-1-0.05","0.1-3-1-0.15","0.1-3-1-0.10","0.1-2-2-0.15","1-5-4-0.2","0.1-5-1-0.15","1.5-5-2-0.2","0.05-4-1-0.15","0.1-5-2-0.15","0.05-4-4-0.15",});
				waves1.Add (new List<string> (){"1-3-4-0.35","0.1-2-1-0.14","0.1-2-2-0.15","0.14-4-4-0.15","0.15-7-2-0.25","0.2-3-0-0.2","0.3-4-1-0.15","1-3-3-1","0.4-4-3-0.5","1-3-4-1","0.25-5-2-0.2","0.05-4-3-0.15","1-5-4-0.4","0.2-3-1-0.3","0.15-4-1-0.6","0.2-3-2-0.5"});
				waves1.Add (new List<string> (){"1-4-4-0.05","0.2-3-1-0.2","0.15-3-2-0.2","0.1-7-1-0.15","0.2-4-1-0.25","0.2-6-3-0.2","0.05-7-4-0.1","0.1-6-1-0.24","0.25-5-2-0.2","0.05-4-3-0.15","0.1-7-0-0.1","0.1-7-1-0.15","0.2-3-3-1","0.1-5-2-0.14","0.3-8-3-0.5","0.1-4-4-0.1",});
				waves1.Add (new List<string> (){"1-5-1-0.25","0.4-3-3-0.5","0.1-4-2-0.15","0.31-2-1-0.21","0.21-2-2-0.11","0.4-5-0-0.2","0.1-7-1-0.15","0.1-2-3-0.2","0.4-5-4-0.7","1-4-1-0.2","0.1-5-0-0.15",
												"0.1-3-3-0.2","0.15-3-0-0.1","0.1-4-1-0.15","0.1-4-2-0.2","0.1-3-4-0.1","0.2-3-1-0.2","0.1-3-2-0.1","0.1-5-3-0.1","0.1-4-1-0.2","0.1-5-1-0.1","0.2-6-4-0.1","0.1-7-1-0.15","0.1-4-1-0.2",});
				waves1.Add (new List<string> (){"1-5-2-0.1","0.05-5-4-0.05","0.05-5-3-0.1","0.05-5-1-0.05","0.15-5-4-0.1","0.05-5-3-0.05","0.2-2-4-0.1","0.05-3-1-0.05","0.05-5-4-0.05","0.05-5-3-0.1","0.05-5-1-0.05","0.15-5-4-0.1","0.05-5-3-0.05","0.2-2-4-0.1","0.05-3-1-0.05",});

				selected_Wave.Add (waves1);

				selectedLives = 11 + GameData.Difficulty;
				selectedMoneys = 100 + 25*GameData.Difficulty;

				break;
			}
		case 3:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","R","R","D","X","X","X","X","X","X","X","D","L","L","SL"});
				selected_Level.Add(new List<string>(){"X","X","X","D","X","X","X","X","X","X","X","D","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","D","X","X","X","X","X","X","X","D","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","R","R","R","R","D","L","L","L","L","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","D","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","D","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","D","L","L","L","L","L","RL","R","R","R","R","R","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","R","R","R","R","D","X","X","X","D","L","L","L","L","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","D","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","D","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"E","L","L","L","L","L","X","X","X","R","R","R","R","R","E"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X","X"});

				waves1.Add (new List<string> (){"1-5-0-1"});
				waves2.Add (new List<string> (){"1-5-0-1"});//1

				waves1.Add (new List<string> (){"1-7-0-0.8","3-9-0-0.5","5-5-1-1.5"});
				waves2.Add (new List<string> (){"1-7-0-0.8","3-9-0-0.5","5-5-1-1.5"});//2

				waves1.Add (new List<string> (){"1-7-0-0.9","2-7-1-1.3","3-10-0-0.3"});
				waves2.Add (new List<string> (){"1-7-0-0.9","2-7-1-1.3","3-10-0-0.3"});//3

				waves1.Add (new List<string> (){"1-15-1-1.5","5-20-0-0.4"});
				waves2.Add (new List<string> (){"1-15-1-1.5","5-20-0-0.4"});//4

				waves1.Add (new List<string> (){"1-5-0-0.2","2-5-1-0.8","3-15-0-0.2","5-25-1-0.3"});
				waves2.Add (new List<string> (){"1-5-0-0.2","2-5-1-0.8","3-15-0-0.2","5-25-1-0.3"});//5

				waves1.Add (new List<string> (){"1-1-2-0.1","1-3-0-0.1","2-3-1-0.1","3-5-2-1.1"});
				waves2.Add (new List<string> (){"1-1-2-0.1","1-3-0-0.1","2-3-1-0.1","3-5-2-1.1"});//6

				waves1.Add (new List<string> (){"1-20-1-0.2","4-20-0-0.1"});
				waves2.Add (new List<string> (){"1-20-1-0.2","4-20-0-0.1"});//7

				waves1.Add (new List<string> (){"1-10-2-1","3-7-0-0.1","3-7-1-0.1"});
				waves2.Add (new List<string> (){"1-10-2-1","3-7-0-0.1","3-7-1-0.1"});//8

				waves1.Add (new List<string> (){"1-3-3-0.1","2-10-2-0.3"});
				waves2.Add (new List<string> (){"1-3-3-0.1","2-10-2-0.3"});//9

				waves1.Add (new List<string> (){"1-5-3-1","3-10-2-0.2"});
				waves2.Add (new List<string> (){"1-5-3-1","3-10-2-0.2"});//10

				waves1.Add (new List<string> (){"1-25-1-0.1","3-10-0-0.1","3-10-2-0.2","4-10-3-0.5","5-20-2-0.1"});
				waves2.Add (new List<string> (){"1-25-1-0.1","3-10-0-0.1","3-10-2-0.2","4-10-3-0.5","5-20-2-0.1"});//11

				waves1.Add (new List<string> (){"1-12-3-0.2","2-10-2-0.1"});
				waves2.Add (new List<string> (){"1-12-3-0.2","2-10-2-0.1"});//12

				waves1.Add (new List<string> (){"1-5-4-0.3","1-20-3-0.2","1-15-2-0.1","1-15-3-0.1"});
				waves2.Add (new List<string> (){"1-5-4-0.3","1-20-3-0.2","1-15-2-0.1","1-15-3-0.1"});//13

				waves1.Add (new List<string> (){"1-25-1-0.01","3-50-0-0.01","5-10-4-0.1"});
				waves2.Add (new List<string> (){"1-25-1-0.01","3-50-0-0.01","5-10-4-0.1"});//14

				waves1.Add (new List<string> (){"1-20-0-0.01","1-20-1-0.01"});
				waves2.Add (new List<string> (){"1-20-0-0.01","1-20-1-0.01"});//15  ******************************

				waves1.Add (new List<string> (){"1-20-2-0.01","1-20-3-0.01"});
				waves2.Add (new List<string> (){"1-20-2-0.01","1-20-3-0.01"});//16

				waves1.Add (new List<string> (){"1-30-2-0.1","4-50-1-0.1"});
				waves2.Add (new List<string> (){"1-30-2-0.1","4-50-1-0.1"});//17

				waves1.Add (new List<string> (){"1-20-4-0.01","4-30-0-0.1","4-30-1-0.1","4-30-2-0.1","4-30-3-0.1","4-30-4-0.1"});
				waves2.Add (new List<string> (){"1-20-4-0.01","4-30-0-0.1","4-30-1-0.1","4-30-2-0.1","4-30-3-0.1","4-30-4-0.1"});//18

				waves1.Add (new List<string> (){"1-30-3-0.01","3-25-4-0.01","3-20-1-0.2","3-15-2-0.1"});
				waves2.Add (new List<string> (){"1-30-3-0.01","3-25-4-0.01","3-20-1-0.2","3-15-2-0.1"});//19

				waves1.Add (new List<string> (){"1-70-0-0.1","5-20-1-0.01","3-15-1-0.001","3-20-4-0.01","3-30-2-0.1","4-15-3-0.1","3-20-3-0.01","4-10-0-0.01","3-50-1-0.001","4-30-4-0.1","2-30-1-0.1","2-30-2-0.1","2-30-3-0.1","2-50-4-0.001"});
				waves2.Add (new List<string> (){"1-70-0-0.1","5-20-1-0.01","3-15-1-0.001","3-20-4-0.01","3-30-2-0.1","4-15-3-0.1","3-20-3-0.01","4-10-0-0.01","3-50-1-0.001","4-30-4-0.1","2-30-1-0.1","2-30-2-0.1","2-30-3-0.1","2-50-4-0.001"});//20

				selected_Wave.Add (waves1);
				selected_Wave.Add (waves2);

				selectedLives = 12 + GameData.Difficulty;
				selectedMoneys = 100 + 25*GameData.Difficulty;

				break;	
			}
		case 4:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","R","RD","R","R","D","X","X","X","R","R","R","R","E"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","D","L","L","L","L","X","X","X","U","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","U","L","L","L","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","U","X"});
				selected_Level.Add(new List<string>(){"X","D","X","R","R","R","R","D","X","X","X","X","U","X"});
				selected_Level.Add(new List<string>(){"X","D","X","U","X","X","X","D","X","X","X","X","U","X"});
				selected_Level.Add(new List<string>(){"X","R","R","U","X","X","X","R","R","R","R","R","U","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});

				selectedLives = 100;
				selectedMoneys = 100;

				break;
			}
		case 5:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","R","R","R","R","R","R","R","R","R","R","R","D","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","L","L","L","L","L","L","L","L","L","L","L","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","R","R","R","R","R","R","R","R","R","R","R","D","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"X","D","L","L","L","L","L","L","L","L","L","L","L","X"});
				selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","R","R","R","R","R","R","R","R","R","R","R","D","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				selected_Level.Add(new List<string>(){"E","L","L","L","L","L","L","L","L","L","L","L","L","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});

				selectedLives = 100;
				selectedMoneys = 100;

				break;
			}
		case 6:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","R","RD","R","R","D","X","X","X","D","L","L","LD","L","SL"});
				selected_Level.Add(new List<string>(){"X","X","D","X","X","D","X","X","X","D","X","X","D","X","X"});
				selected_Level.Add(new List<string>(){"X","X","R","R","R","D","X","X","X","D","L","L","L","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","D","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","D","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","D","X","X","X","D","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","R","R","D","L","L","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","D","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"E","L","L","X","X","X","X","D","X","X","X","X","R","R","E"});
				selected_Level.Add(new List<string>(){"X","X","U","X","X","X","X","D","X","X","X","X","U","X","X"});
				selected_Level.Add(new List<string>(){"X","X","U","L","LD","L","L","LR","R","R","RD","R","U","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","D","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","D","X","X","X","X"});
				selected_Level.Add(new List<string>(){"X","X","X","X","E","X","X","X","X","X","E","X","X","X","X"});
				
				selectedLives = 100;
				selectedMoneys = 100;
				break;
			}
		}

		DimX = selected_Level[0].Count;
		DimY = selected_Level.Count;
	}
	
	//Reads custom levels from CustomLevels folder,which is located in the same dir as the exe
	public static string[] ReadCustomLevels(){
		//get path
		string path = System.IO.Directory.GetCurrentDirectory() + "\\CustomLevels";
		//if directory !exists create it
		if(!System.IO.Directory.Exists(path)){
			System.IO.Directory.CreateDirectory(path);
		}
		//get all files with ptl extension
		string[] contents = System.IO.Directory.GetFiles(path,"*.ptl");
		//return list of paths
		return contents;
	}

	//Reads a custom level
	public static void ReadCustom(string path){
		selected_Level.Clear();
		selected_Wave.Clear ();
		isSurvival = true;
		selectedLives = 50;
		selectedMoneys = 100;

		string[] lines = System.IO.File.ReadAllLines(path);
		//Add to selected level
		for(int i =0;i<lines.Length;i++){
			selected_Level.Add(new List<string>());
			string[] parts = lines[i].Split(' ');
			foreach(string p in parts){
				selected_Level[i].Add(p);
			}
			DimX = selected_Level[0].Count;
			DimY = selected_Level.Count;

		}
	}


	//GETTERS/SETTERS

	public static List<List<string>> GetSelectedLevel(){
		return selected_Level;
	}

	public static List<List<List<string>>> GetSelectedWave(){
		return selected_Wave;
	}

	public static int SelectedLives{
		get{ return selectedLives; }
		set{ selectedLives = value; }
	}

	public static int SelectedMoneys{
		get{ return selectedMoneys; }
		set{ selectedMoneys = value; }
	}

	public static bool IsSurvival{
		get{ return isSurvival; }
		set{ isSurvival = value; }
	}

	public static int NumbersOfTracks
	{
		get{ return numberOfTracks;}
	}

	public static int getDimX(){
		return DimX;
	}

	public static int getDimY(){
		return DimY;
	}

	public static int Selected_level {
		get {return selected_level;}
		set {selected_level = value;}
	}
}

/*selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});*/
