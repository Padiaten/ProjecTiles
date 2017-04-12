using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile {

	bool canPlaceTower = true;
	// Use this for initialization
	void Start () {
		
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/TempSprites/Grass");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void set_canPlaceTower(bool t){
		canPlaceTower = t;
	}
}
