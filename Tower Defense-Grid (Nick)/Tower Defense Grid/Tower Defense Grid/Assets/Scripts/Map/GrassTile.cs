using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile {
	private bool canPlaceBuilding = true;
	// Use this for initialization
	void Start () {
		
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MapSprites/Grass");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool getCanPlaceBuilding(){
		return canPlaceBuilding;
	}

	public void setCanPlaceBuilding(bool t){
		canPlaceBuilding = t;
	}

}
