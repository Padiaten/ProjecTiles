using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInteractions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseEnter(){
		 transform.Find("Range").GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
	}

	public void OnMouseExit(){
		transform.Find("Range").GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;

	}

}
