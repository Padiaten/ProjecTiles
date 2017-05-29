using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : Tile {

	public List<GameObject> NextTiles = new List<GameObject>();
	public List<GameObject> PrevTiles = new List<GameObject>();


	//Set tag
	void Start () {
        //canPlaceTower = false;
        tag = "Path";
	}


	//add previous tile PrevTile list
	public void add_PrevTile(GameObject v){
		PrevTiles.Add(v);
	}
	//add next tile to NextTile list
	public void add_NextTile(GameObject v){
		NextTiles.Add(v);
	}

	//Sets pathtile type and handles orientation
	public void set_PathTile_Type(int mapsize_x,int mapsize_y){
		//Path type selection is based on total number of connections to specific tile
		int total_connections = NextTiles.Count + PrevTiles.Count;

		switch(total_connections){
			//Straight path on map borders.Use for start and end
			case 1:
				Ttype = TileType.PathStraight;
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_straight");
				
				//Create start/end graphics
				GameObject transitiongraphic =new GameObject();
				transitiongraphic.AddComponent<SpriteRenderer>();
				transitiongraphic.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-1);
				transitiongraphic.transform.localScale = new Vector3(1f,1.25f,1f);
				if(GameObject.Find("GameFlow").GetComponent<GridController>().GetStartTiles().Contains(this.gameObject)){
					transitiongraphic.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/MapSprites/entrypoint",typeof(Sprite));
					transitiongraphic.name = "Entry Point";
				}else{
					transitiongraphic.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/MapSprites/exitpoint",typeof(Sprite));
					transitiongraphic.name = "Entry Point";
				}
				if(this.x == 0 || this.x == mapsize_x-1){
					//print(this.x);
					this.transform.rotation = Quaternion.Euler(0,0,90);
					transitiongraphic.transform.rotation = Quaternion.Euler(0,0,90);
				}
			  	break;

			case 2:
				bool checkX = PrevTiles[0].GetComponent<PathTile>().getX() == NextTiles[0].GetComponent<PathTile>().getX();
				bool checkY = PrevTiles[0].GetComponent<PathTile>().getY() == NextTiles[0].GetComponent<PathTile>().getY();
		 		if(checkX || checkY){
					//Straight path inside map
			   		Ttype = TileType.PathStraight;
					this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_straight");
					if(checkY){
						this.transform.rotation = Quaternion.Euler(0,0,90);
					}
				}else{
					//Simple Corner
					Ttype = TileType.PathCorner;
					this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_corner");	
					bool Xbigger = PrevTiles[0].GetComponent<PathTile>().getX() > this.x || NextTiles[0].GetComponent<PathTile>().getX() > this.x;
					bool Ybigger = PrevTiles[0].GetComponent<PathTile>().getY() > this.y || NextTiles[0].GetComponent<PathTile>().getY() > this.y;
					if(Xbigger && Ybigger){
						this.transform.rotation = Quaternion.Euler(0,0,90);
					}else if(!Xbigger && !Ybigger){
						this.transform.rotation = Quaternion.Euler(0,0,270);
					}else if(!Xbigger && Ybigger){
						this.transform.rotation = Quaternion.Euler(0,0,180);
					}
			   }
			   break;
			case 3:
				//T formation 
				Ttype = TileType.PathTShape;
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_tshape");	
				if(GameObject.Find("G " + x + "," + (y-1).ToString()) != null){
					this.transform.rotation = Quaternion.Euler(0,0,180);
				}else if(GameObject.Find("G " + (x+1).ToString() + "," + y) != null){
					this.transform.rotation = Quaternion.Euler(0,0,270);
				}else if(GameObject.Find("G " + (x-1).ToString() + "," + y) != null){
					this.transform.rotation = Quaternion.Euler(0,0,90);
				}	
				break;
			case 4:
				//Crossroads
				Ttype = TileType.PathCrossroad;
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_cross");	
				break;
		}
	}

	//Returns next tile(Random selection)
	public GameObject getNextTile_Random(){
		return(NextTiles[Random.Range(0,NextTiles.Count)]);
	}

	//Returns next tile(Selection based on given enemy id)
	public GameObject getNextTile_idBased(int id){
		return(NextTiles[NextTiles.Count%id]);
	}

}
