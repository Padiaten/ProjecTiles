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
	private static bool isSurvival;
	private static int numberOfTracks = 5;//οποτε προσθετεις καποια πιστα ενημερωσε και την μεταβλητη

	private static int DimX=10,DimY=10;

	public static void PickLevel(int i){
		selected_Level.Clear();
		selected_Wave.Clear ();
		waves1.Clear ();
		waves2.Clear ();
		switch(i){
		case 1:
			{
				selected_Level.Add (new List<string> (){ "X", "X", "X", "SD", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "R", "D", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "L", "LD", "L", "L", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "X", "D", "X", "U", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "X", "R", "R", "U", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "R", "D", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "E", "X", "X", "X", "X", "X" });

				waves1.Add (new List<string> (){"1-2-4-1","1-2-0-1","1-2-1-1","1-2-1-1","1-2-1-1"});
				waves1.Add (new List<string> (){"1-100-0-0.3","1-100-1-0.3","1-100-2-0.3","1-100-3-0.3","1-100-4-0.3"});

				selected_Wave.Add (waves1);

				selectedLives = 100;
				selectedMoneys = 200;
			
				break;
			}
		case 2:
			{
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "SD", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "D", "L", "L", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "D", "X", "U", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "L", "LR", "R", "DR", "R", "U", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "SR", "R", "D", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "D", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "R", "R", "D", "L", "L", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "D", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });
				selected_Level.Add (new List<string> (){ "X", "X", "X", "X", "E", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" });

				waves2.Add (new List<string> (){"1-2-0-5"});
				waves2.Add (new List<string> (){"1-2-4-4"});
				waves2.Add (new List<string> (){"1-2-0-3"});
				waves2.Add (new List<string> (){"1-2-4-2"});
				waves2.Add (new List<string> (){"1-10-4-1"});
				waves2.Add (new List<string> (){"1-10-4-0.5"});
				waves2.Add (new List<string> (){"1-10-4-0.1"});
				waves2.Add (new List<string> (){"1-10-4-0.05"});
				waves2.Add (new List<string> (){"1-10-4-0.01"});

				selected_Wave.Add (waves2);
				selected_Wave.Add (waves1);

				selectedLives = 200;
				selectedMoneys = 150;

				break;
			}
		case 3:
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

				waves1.Add (new List<string> (){"1-1-0-1"});
				waves1.Add (new List<string> (){"1-6-0-1","2-6-1-2"});
				//waves1.Add (new List<string> (){"1-6-0-1","2-10-1-2","2-7-2-2","1-12-3-2","4-5-4-2"});

				selected_Wave.Add (waves1);

				selectedLives = 1;
				selectedMoneys = 100;

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
				selectedMoneys = 200;

				break;
			}
		case 5:
			{
				selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"SR","D","X","X","X","X","X","X","X","X","X","X","X","X"});
				selected_Level.Add(new List<string>(){"E","L","X","X","X","X","X","X","X","X","X","X","X","X"});
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

				selectedLives = 100;
				selectedMoneys = 200;

				break;
			}
		case 6:
			{
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


	public static List<List<string>> GetSelectedLevel(){
		return selected_Level;
	}

	public static List<List<List<string>>> GetSelectedWave(){
		return selected_Wave;
	}

	public static int SelectedLives{
		get{ return selectedLives; }
	}

	public static int SelectedMoneys{
		get{ return selectedMoneys; }
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
