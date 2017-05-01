using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MainEnemy {
	private float coefSpeed;
	private GameObject g;
	private Vector2 vectorNext;
	private bool flag;
	GameObject GameFlow;
	private int health = 15;
	private int worth = 10;
	// Use this for initialization
	void Start () {
		base.Start();
		GameFlow = GameObject.Find("GameFlow");
		coefSpeed = 3;
		flag = false;
		List<GameObject> listStarTiles = GameFlow.GetComponent<GridController>().GetStartTiles();
		g = listStarTiles[0].GetComponent<PathTile> ().getNextTile_Random ();
		vectorNext = g.GetComponent<Tile> ().getCoords ();
	}

	// Update is called once per frame
	void Update () {
		Movement (coefSpeed,ref vectorNext,ref flag,ref g);
	}

	public void Hit(int hitpoints)//hitpoints: το hit του tower η συναρτηση καλειται καθε φορα που το enemy χτυπηθει
	{
		MainHit (hitpoints,health,worth);
	}
}
