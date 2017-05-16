using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private int kills = 0;
	private int money;
	private int lives;

	// Use this for initialization
	void Start () {
		lives = LevelHandler.SelectedLives;
		money = LevelHandler.SelectedMoneys;

		UpdateHealth();
		UpdateGold();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void  UpdateHealth(){
		GameObject.Find ("HealthText").GetComponent<Text> ().text = lives.ToString ();
	}

	public void UpdateGold(){
		GameObject.Find ("GoldText").GetComponent<Text> ().text = money.ToString ();
	}

	public void ControLives()
	{
		if (lives <= 0)
			this.gameObject.GetComponent<FlowController> ().EndGame ();
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
