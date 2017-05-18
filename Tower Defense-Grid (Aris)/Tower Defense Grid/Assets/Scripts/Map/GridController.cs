using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {
	
	List<List<string>> map = new List<List<string>>();
	//Έχει τα πλακίδια-αφετηρία
	protected List<GameObject> StartTiles = new List<GameObject>();
	void Start () {
		drawMap(LevelHandler.GetSelectedLevel());
	}
	


	void drawMap(List<List<string>> map){
		//Scan 1 of 2,identify general tile type and place on grid
		for(int i=0;i<map.Count;i++){
			for(int j=0;j<map[i].Count;j++){
				GameObject go = new GameObject();
				go.AddComponent<SpriteRenderer>();
				//go.AddComponent<SpriteRenderer>();
				if(map[i][j] == "X"){
					go.AddComponent<GrassTile>();
					go.GetComponent<GrassTile>().initializeTile(j,map[j].Count-1-i);
					go.name = "G" + " " + j + "," + (map[j].Count-1-i).ToString();
				}else{
					go.AddComponent<PathTile>();
					go.GetComponent<PathTile>().initializeTile(j,map[j].Count-1-i);
					go.name = "P" + " " + j + "," + (map[j].Count-1-i).ToString();

					//Ελένχει αν ειναι αφετηρια και το βαζει στη λιστα
					}if(map[i][j].Contains("S")){
						StartTiles.Add(go);
					}
			}
		}

		//Scan 2 of 3,assign previous and next tiles to each tile
		for(int i=0;i<map.Count;i++){
			for(int j=0;j<map[i].Count;j++){
				//print("Tried to access:" + map[map.Count-1-i][j]+" " + j + "," + i);
				if(map[map.Count-1-i][j] != "X" && map[map.Count-1-i][j] != "B"){
					string cur_tile_name ="P" + " " + j + "," + i;
					//print("Current Tile:" + cur_tile_name);
					GameObject cur_tile = GameObject.Find(cur_tile_name);
					//print("Cur Tile:" + cur_tile_name);
					if(map[map.Count-1-i][j].Contains("U")){
						string next_tile_name = "P" + " " + j + "," + (i+1).ToString();
						GameObject p = GameObject.Find(next_tile_name);
						//print("Next Tile:" + next_tile_name);
						p.GetComponent<PathTile>().add_PrevTile(cur_tile);
						cur_tile.GetComponent<PathTile>().add_NextTile(p);
					}

					if(map[map.Count-1-i][j].Contains("D")){
						string next_tile_name = "P" + " " + j + "," + (i-1).ToString();
						GameObject p = GameObject.Find(next_tile_name);
						//print("Next Tile:" + p);
						p.GetComponent<PathTile>().add_PrevTile(cur_tile);
						cur_tile.GetComponent<PathTile>().add_NextTile(p);
					}

					if(map[map.Count-1-i][j].Contains("L")){
						string next_tile_name = "P" + " " + (j-1).ToString() + "," + i;
						GameObject p = GameObject.Find(next_tile_name);
					//	print("Next Tile:" + next_tile_name);
						p.GetComponent<PathTile>().add_PrevTile(cur_tile);
						cur_tile.GetComponent<PathTile>().add_NextTile(p);
					}

					if(map[map.Count-1-i][j].Contains("R")){
						string next_tile_name = "P" + " " + (j+1).ToString() + "," + i;
						GameObject p = GameObject.Find(next_tile_name);
						//print("Next Tile:" + next_tile_name);
						p.GetComponent<PathTile>().add_PrevTile(cur_tile);
						cur_tile.GetComponent<PathTile>().add_NextTile(p);
					}
				}
			}
		}

		//Scan 3 of 3,identify specific path tile and orientation
		for(int i=0;i<map.Count;i++){
			for(int j=0;j<map[i].Count;j++){
				if(map[map.Count-1-i][j] != "X" && map[map.Count-1-i][j] != "B"){
					string tile_name = "P" + " " + j + "," + i;
					int mapsize_x = map.Count;
					int mapsize_y = map[j].Count;
					GameObject go = GameObject.Find(tile_name);
					go.GetComponent<PathTile>().set_PathTile_Type(mapsize_x,mapsize_y);
				}
			
			}
		}
		GetComponent<FlowController>().startWaveControler();
	}

	public List<GameObject> GetStartTiles(){
		//print("returned something," + StartTiles.Count);
		return StartTiles;
	}


}