using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

	bool hovering = true;
	private GameObject InfoMessage;

	private int towerCost;

	//Starts hovering
	void Start () {        
		GetComponentInChildren<CircleCollider2D>().enabled = false;
        GetComponentInChildren<BoxCollider2D>().enabled = false;
		transform.Find("Range").GetComponent<SpriteRenderer>().enabled = false;

		InfoMessage = GameObject.Find("InfoMessage");
		//print("InfoMessage:" + InfoMessage);
    }

	//Handles the rest of the hovering,and also cost
	void Update () {
        //Position tower on mouse
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
					InfoMessage.GetComponent<ShowInfoText>().displayMessage(1);
					//print("Cannot place on path :(");
				//Dont place on occupied tiles!
				}else if(GameObject.Find(Gname_test).GetComponent<GrassTile>().getCanPlaceBuilding() == false){
					InfoMessage.GetComponent<ShowInfoText>().displayMessage(2);
					//print("Cannot place on occupied tile");
				//You can place here bro.
				}else if(GameObject.Find("GameFlow").GetComponent<Player>().Money < towerCost){
					InfoMessage.GetComponent<ShowInfoText>().displayMessage(3);
					//print("Not enough money");		
				}else{
					GameObject.Find ("GameFlow").GetComponent<Player> ().AddInTowerList (this.gameObject.GetComponentInChildren<Tower> ().Id,true);
					GameObject.Find("GameFlow").GetComponent<Player>().UpdateGold((-towerCost));
					//print("Tower placed @ "+ position.x +"," +position.y);
					GameObject.Find(Gname_test).GetComponent<GrassTile>().setCanPlaceBuilding(false);
					GetComponentInChildren<CircleCollider2D>().enabled = true;
                    GetComponentInChildren<BoxCollider2D>().enabled = true;
					transform.Find("Range").GetComponent<SpriteRenderer>().enabled = true;
					GetComponentInChildren<Tower>().enabled = true;
					GetComponent<TowerInteractions>().enabled = true;
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

	public void setTowerCost(int i){
		towerCost = i;
	}

	public bool CancelPlacement(){
		Destroy(this.gameObject);
		return false;
	}

}
