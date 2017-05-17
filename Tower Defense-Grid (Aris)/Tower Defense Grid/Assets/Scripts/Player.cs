using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private int kills = 0;
	private int money;
	private int lives;
	private int score = 0;
	private bool initial = false;
	private List<int> killist = new List<int> ();
	//private List<int> 

	public void AddInKillist(int id)
	{
		if (!initial) {
			int count = GameObject.Find ("GameFlow").GetComponent<WaveControler> ().ListWithEnemies.Count;
			for (int i = 0; i < count; i++) {
				killist [i] = 0;
			}
		}

		killist [id]++;
	}

	//public void 

	// Use this for initialization
	void Start () {
		lives = LevelHandler.SelectedLives;
		money = LevelHandler.SelectedMoneys;

		UpdateHealth();
		UpdateGold();
		UpdateScore ();
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

	public void UpdateScore()
	{
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = score.ToString ();
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

	public int Score
	{
		get{ return score; }
		set{ score = value; }
	}
}
