using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the whole game
public class FlowController : MonoBehaviour {

	//PLAYER
	private int kills = 0;
	private int money = 200;
	private int lives = 100;
	//SCENES
	public GameObject gameOverUI;
	public GameObject pauseUI;
	public GameObject levelCompleteUI;
	//DIFFRENTS
	private float oldTimeScale;
	private int numberOFEnemies = 0;
	private GameObject gameFlow;
	private bool waveStart = false;
	private bool completeLevel = false;
	private bool flagEnd = false;

	// Use this for initialization
	void Start () {
		GetComponent<GridController>().enabled = true;
		gameFlow = GameObject.Find("GameFlow");
		UpdateHealth();
		UpdateGold();
		//GetComponent<WaveControler>().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) && !gameOverUI.activeSelf && !levelCompleteUI.activeSelf) {
			Pause();
		}
	}

	public void startWaveControler(){
		GetComponent<WaveControler>().enabled = true;
		waveStart = true;
	}

	public void TowerHover(int i){
		GameObject tower1,tower2,tower3,tower4,tower5,tower6;
		GameObject new_tower = null;

		tower1 = (GameObject)Resources.Load("Prefabs/Towers/Tower",typeof(GameObject));
		tower2 = (GameObject)Resources.Load("Prefabs/Towers/Slow Tower",typeof(GameObject));
		tower3 = (GameObject)Resources.Load("Prefabs/Towers/Buff Tower",typeof(GameObject));
		tower4 = (GameObject)Resources.Load("Prefabs/Towers/Canon Tower",typeof(GameObject));
		tower5 = (GameObject)Resources.Load("Prefabs/Towers/Global Tower",typeof(GameObject));
		tower6 = (GameObject)Resources.Load("Prefabs/Towers/Roundhouse Tower", typeof(GameObject));

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
		new_tower.GetComponent<Hover>().setTowerCost(TowerCost.getCost(i));



	}

	public void StartWaves_UpdateSpeed(){
		if(GetComponent<WaveControler>().OutOfWaves && numberOFEnemies==0 && !GetComponent<WaveControler>().EndOfWaves){
			if(Time.timeScale == 2)
				Time.timeScale = 1;
			GetComponent<WaveControler>().callWave();
			GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/speedup",typeof(Sprite));
		}else{
			AdjustGameSpeed();
		}
	}

	public void  UpdateHealth(){
		GameObject.Find("HealthText").GetComponent<Text>().text = lives.ToString();
	}

	public void UpdateGold(){
		GameObject.Find("GoldText").GetComponent<Text>().text = money.ToString();
	}

	public void AdjustGameSpeed(){
		if(Time.timeScale == 1){
			Time.timeScale = 2;
			GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/speedup_full",typeof(Sprite));
		}else if(Time.timeScale == 2){
			Time.timeScale = 1;
			GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/speedup",typeof(Sprite));
		}
	}
	
	public void ControLives()
	{
		if(lives<=0) EndGame();
	}
	
	public void ControlNumOfEnemies()
	{
		if(numberOFEnemies==0 && GetComponent<WaveControler>().OutOfWaves && !GetComponent<WaveControler>().EndOfWaves)
			GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/startlevel",typeof(Sprite));
		else if(!completeLevel && gameFlow.GetComponent<WaveControler> ().EndOfWaves && numberOFEnemies == 0 && !flagEnd){
			LevelComplete ();
			completeLevel = true;
		}
	}

	//SCENES IN GAME
	public void EndGame()
	{
		Time.timeScale = 0;
		gameOverUI.SetActive (true);
	}
	
	public void LevelComplete(){
		levelCompleteUI.SetActive (true);
		Time.timeScale = 0;
	}
	
	public void Pause()
	{
		pauseUI.SetActive (!pauseUI.activeSelf);
		if (pauseUI.activeSelf) {
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		} else {
			Time.timeScale = oldTimeScale;
		}
	}

	//MENU BUTTON IN GAME
	public void Continue(){
		pauseUI.SetActive (false);
		Time.timeScale = oldTimeScale;
	}

	public void Restart()
	{
		Application.LoadLevel("MainGame");
		Time.timeScale = 1f;
	}

	public void Menu()
	{
		Application.LoadLevel ("MainMenu");
		Time.timeScale = 1f;
	}
	
	public void ContinueLevelCompleteUI()
	{
		Application.LoadLevel ("LevelSelect");
		Time.timeScale = 1f;
	}

	//GETTERS
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

	public int NumbersOfEnemies{
		get{ return numberOFEnemies;}
		set{ numberOFEnemies = value;}
	}
}

