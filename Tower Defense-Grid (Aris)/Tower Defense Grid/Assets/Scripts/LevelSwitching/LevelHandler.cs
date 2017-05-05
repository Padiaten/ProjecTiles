using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class LevelHandler{

	private static List<List<string>> Selected_Level = new List<List<string>>();
	private static int DimX=10,DimY=10;

	public static void PickLevel(int i){
		Selected_Level.Clear();
		switch(i){
			case 1:
				Selected_Level.Add(new List<string>(){"X","X","X","SD","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","R","D","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","L","LD","L","L","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","D","X","U","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","R","R","U","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","R","D","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","E","X","X","X","X","X"});
				break;
			case 2:
				Selected_Level.Add(new List<string>(){"X","X","X","X","SD","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","D","L","L","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","D","X","U","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","L","LR","R","DR","R","U","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","X","X","D","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"SR","R","D","X","X","X","D","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","X","X","D","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","R","R","D","L","L","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","D","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","E","X","X","X","X","X","X","X","X","X","X"});
				break;
		case 3:Selected_Level.Add(new List<string>(){"X","SD","X","X","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","D","X","X","X","X","X","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","R","R","R","R","R","D","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","X","X","D","X","X","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","L","LD","L","LR","R","R","RD","R","D","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","D","X","X","X","X","D","X","D","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","D","X","X","X","X","D","X","D","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","R","R","D","D","L","L","X","D","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","D","X","X","X","D","D","X","X","X","D","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","R","R","R","R","R","R","D","L","L","L","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","D","X","X","X","X","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","R","R","R","R","D","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","D","X"});
				Selected_Level.Add(new List<string>(){"X","X","X","X","X","X","X","X","X","X","X","X","E","X"});
				break;
		}

		DimX = Selected_Level[0].Count;
		DimY = Selected_Level.Count;
	}


	public static List<List<string>> GetSelectedLevel(){
		return Selected_Level;
	}

	public static int getDimX(){
		return DimX;
	}

	public static int getDimY(){
		return DimY;
	}
}


