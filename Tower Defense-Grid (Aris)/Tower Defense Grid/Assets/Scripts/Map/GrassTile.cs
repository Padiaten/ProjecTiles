using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class GrassTile : Tile {
	private bool canPlaceBuilding = true;
	//Set sprite
	void Start () {
		
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/Grass");
	}
	

	//GETTERS/SETTERS
	public bool getCanPlaceBuilding(){
		return canPlaceBuilding;
	}

	public void setCanPlaceBuilding(bool t){
		canPlaceBuilding = t;
	}

}
