using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MainEnemy {
	private float coefSpeed;
	private GameObject g;
	private Vector2 vectorNext;
	private bool flag;
	GameObject GameFlow;
	// Use this for initialization
	void Start () {
		GameFlow = GameObject.Find("GameFlow");
		coefSpeed = 5;
		flag = false;
		List<GameObject> listStarTiles = GameFlow.GetComponent<GridController>().GetStartTiles();
		g = listStarTiles[0].GetComponent<PathTile> ().getNextTile_Random ();
		vectorNext = g.GetComponent<Tile> ().getCoords ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement (coefSpeed,ref vectorNext,ref flag,ref g);
	}
}
