﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {


	private Vector2 v2;
	public GameObject enem;
    private int i;
	GameObject GameFlow;
	// Use this for initialization
	void Start () {
		GameFlow = GameObject.Find("GameFlow");
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
            i++;
			List<GameObject> startTiles = GameFlow.GetComponent<GridController>().GetStartTiles();
			v2 = startTiles [0].GetComponent<PathTile> ().getCoords ();
			//enem = GameObject.Find ("Enemy");
			GameObject go = Instantiate(enem,v2, Quaternion.identity) as GameObject;
			go.name = "Enemy";
		}


	}
}
