using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour {

	private int kills = 0;
	private int money = 0;
	private int lives = 100;//ενδεικτικο


	// Use this for initialization
	void Start () {
		GetComponent<GridController>().enabled = true;
		//GetComponent<WaveControler>().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startWaveControler(){
		GetComponent<WaveControler>().enabled = true;
	}

	public void TowerHover(int i){
		GameObject tower1,tower2,tower3,tower4,tower5,tower6;
		GameObject new_tower = null;

		tower1 = (GameObject)Resources.Load("Prefabs/Tower",typeof(GameObject));
		tower2 = (GameObject)Resources.Load("Prefabs/Tower",typeof(GameObject));
		tower3 = (GameObject)Resources.Load("Prefabs/Tower",typeof(GameObject));
		tower4 = (GameObject)Resources.Load("Prefabs/Tower",typeof(GameObject));
		tower5 = (GameObject)Resources.Load("Prefabs/Tower",typeof(GameObject));
		tower6 = null;

		Vector2 coords =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		coords = new Vector2(Mathf.Round(coords.x),Mathf.Round(coords.y));
	
		switch(i){
			case 1:
				new_tower = Instantiate(tower1,coords,Quaternion.identity);
				break;
			case 2:
				new_tower = Instantiate(tower2,coords,Quaternion.identity);
				break;
			case 3:
				new_tower = Instantiate(tower3,coords,Quaternion.identity);
				break;
			case 4:
				new_tower = Instantiate(tower4,coords,Quaternion.identity);
				break;
			case 5:
				new_tower = Instantiate(tower5,coords,Quaternion.identity);
				break;
			case 6:
				new_tower = Instantiate(tower6,coords,Quaternion.identity);
				break;
			}
		new_tower.GetComponent<Hover>().enabled = true;


	}
		

	public void AdjustGameSpeed(){
		if(Time.timeScale == 1){
			Time.timeScale = 2;
		}else if(Time.timeScale == 2){
			Time.timeScale = 1;
		}
	}

	public int Kill{
		get{ return kills;}
		set{ kills = value;}
	}

	public int Money{
		get{ return money;}
		set{ money = value;}
	}

	public int Lives{
		get{ return lives;}
		set{ lives = value;}
	}
}
