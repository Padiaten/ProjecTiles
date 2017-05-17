using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : Tile {

	public List<GameObject> NextTiles = new List<GameObject>();
	public List<GameObject> PrevTiles = new List<GameObject>();


	// Use this for initialization
	void Start () {
        //canPlaceTower = false;
        tag = "Path";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void add_PrevTile(GameObject v){
		PrevTiles.Add(v);
	}

	public void add_NextTile(GameObject v){
		NextTiles.Add(v);
	}

	//Θέτει τον τύπο μονοπατιού και το περιστρέφει κατάλληλα
	//Sets pathtile type and handles orientation
	public void set_PathTile_Type(int mapsize_x,int mapsize_y){
		//Ο τύπος μονοπατιού βασίζεται στο συνολικό αριθμό συνδέσεων του πλακιδίου
		//Path type selection is based on total number of connections to specific tile
		int total_connections = NextTiles.Count + PrevTiles.Count;

		switch(total_connections){
			//Ίσιο μονοπάτι στα άκρα του χάρτη.Χρήση για αφετηρία και τέλος διαδρομής
			//Straight path on map borders.Use for start and end
			case 1:
				Ttype = TileType.PathStraight;
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_straight");
				if(this.x == 0 || this.x == mapsize_x){
					//print(this.x);
					this.transform.rotation = Quaternion.Euler(0,0,90);
				}
			  	break;

			case 2:
				bool checkX = PrevTiles[0].GetComponent<PathTile>().getX() == NextTiles[0].GetComponent<PathTile>().getX();
				bool checkY = PrevTiles[0].GetComponent<PathTile>().getY() == NextTiles[0].GetComponent<PathTile>().getY();
		 		if(checkX || checkY){
					//Ίσιο μονοπάτι στο εσωτερικό του χάρτη
					//Straight path inside map
			   		Ttype = TileType.PathStraight;
					this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_straight");
					if(checkY){
						this.transform.rotation = Quaternion.Euler(0,0,90);
					}
				}else{
					//Απλή γωνία 
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
				//Μονοπάτι σχήματος "Τ"
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
				//Σταυροδρόμι
				//Crossroads
				Ttype = TileType.PathCrossroad;
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/path_cross");	
				break;
		}
	}

	//Επιστρέφει το επόμενο πλακίδιο(Επιλέγει τυχαία)
	//Returns next tile(Random selection)
	public GameObject getNextTile_Random(){
		return(NextTiles[Random.Range(0,NextTiles.Count)]);
	}

	//Επιστρέφει το επόμενο πλακίδιο(H επιλογή γίνεται με βάση το δοσμένο id εχθρού)
	//Returns next tile(Selection based on given enemy id)
	public GameObject getNextTile_idBased(int id){
		return(NextTiles[NextTiles.Count%id]);
	}

}
