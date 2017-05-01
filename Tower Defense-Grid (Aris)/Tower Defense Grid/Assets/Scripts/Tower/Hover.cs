using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

	bool hovering = true;


    // Use this for initialization
    void Start () {
		GetComponentInChildren<Tower>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Τοποθέτηση Πύργων
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		position = new Vector2(Mathf.Round(position.x),Mathf.Round(position.y));

		if(hovering){


			//Restrict tower position within map border
			if(position.x < 0){
				position.x = 0;
			}else if(position.x > LevelHandler.getDimX()-1){
				position.x = LevelHandler.getDimX()-1;
			}

			if(position.y < 0){
				position.y = 0;
			}else if(position.y > LevelHandler.getDimY()-1){
				position.y = LevelHandler.getDimY()-1;
			}

			transform.position = position;

			//Left click to place
			if(Input.GetMouseButtonDown(0)){

				string Pname_test = "P " + position.x + "," + position.y;
				string Gname_test = "G " + position.x + "," + position.y;
				//Dont place on the path!
				if(GameObject.Find(Pname_test)){
					print("Cannot place on path :(");
				//Dont place on occupied tiles!
				}else if(GameObject.Find(Gname_test).GetComponent<GrassTile>().getCanPlaceBuilding() == false){
					print("Cannot place on occupied grasstile :(");
				//You can place here bro.
				}else{
					print("Tower placed @ "+ position.x +"," +position.y);
					GameObject.Find(Gname_test).GetComponent<GrassTile>().setCanPlaceBuilding(false);
					GetComponentInChildren<Tower>().enabled = true;
					hovering = false;
					this.GetComponent<Hover>().enabled = false;
				}

			}
			//Right click to cancel placement
			if(Input.GetMouseButtonDown(1)){
				print("Cancelled");
				hovering = CancelPlacement();
			}

		}
    }

	public bool CancelPlacement(){
		Destroy(this.gameObject);
		return false;
	}

}
