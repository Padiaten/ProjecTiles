using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
//Controls the whole game
public class FlowController : MonoBehaviour {

	//SCENES
	public GameObject gameOverUI;
	public GameObject pauseUI;
	public GameObject levelCompleteUI;
	public GameObject StatisticsUI;
	//
	private float oldTimeScale;
	private int numberOFEnemies = 0;
	private GameObject gameFlow;
	private bool completeLevel = false;//εχει συμπληρωθει το level;
	private bool waveStart = false;
	private int oldScene;

	// Use this for initialization
	void Start () {
		GetComponent<GridController>().enabled = true;
		GetComponent<Player>().enabled = true;
		GetComponent<Player> ().StartChronometer ();
		gameFlow = GameObject.Find("GameFlow");
		//GetComponent<WaveControler>().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) && !gameOverUI.activeSelf && !levelCompleteUI.activeSelf) {
			Pause();
		}
		if (waveStart) {
			if (numberOFEnemies == 0 && GetComponent<WaveControler> ().OutOfWaves && !GetComponent<WaveControler> ().EndOfWaves)
				GameObject.Find ("Start_and_Speed_Button").GetComponent<Image> ().sprite = (Sprite)Resources.Load ("Sprites/GUI/startlevel", typeof(Sprite));
			else if (!completeLevel && gameFlow.GetComponent<WaveControler> ().EndOfWaves && numberOFEnemies == 0 && gameFlow.GetComponent<Player>().Lives > 0) {
				//!completeLevel:για να ειμαστε σιγουροι πως δεν θα καλεστει ξανα 
				completeLevel = true;
				LevelComplete ();
			}
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
		tower6 = (GameObject)Resources.Load("Prefabs/Towers/Canon Tower", typeof(GameObject));;

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
			//!GetComponent<WaveControler>().EndOfWaves: αλλιως θα καλούνταν η callWave χωρις βεβαια να κανει κατι αλλα θα εμποδιζε την ταχυτητα να αυξηθει(στο τελευταιο κυμα)
			if(Time.timeScale == 2)
				Time.timeScale = 1;
			GetComponent<WaveControler>().callWave();
			GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/speedup",typeof(Sprite));
		}else{
			AdjustGameSpeed();
		}
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
		
	//SCENES IN GAME
	public void EndGame()
	{
		GetComponent<Player> ().EndChronometer();
		Time.timeScale = 0;
		gameOverUI.SetActive (true);
		GameObject.Find ("TextScoreGameOver").GetComponent<Text> ().text = gameFlow.GetComponent<Player> ().Score.ToString ();
	}
	
	public void LevelComplete(){
		GetComponent<Player> ().EndChronometer();
		Time.timeScale = 0;
		levelCompleteUI.SetActive (true);
		GameObject.Find ("TextScoreLevelComplete").GetComponent<Text> ().text = gameFlow.GetComponent<Player> ().Score.ToString (); 
	}
	
	public void Pause()
	{
		pauseUI.SetActive (!pauseUI.activeSelf);
		if (pauseUI.activeSelf) {
			GetComponent<Player> ().StopChronometer ();
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		} else {
			GetComponent<Player> ().StartChronometer ();
			Time.timeScale = oldTimeScale;
		}
	}

	//MENU BUTTON IN GAME
	public void Continue(){
		pauseUI.SetActive (false);
		Time.timeScale = oldTimeScale;
		GetComponent<Player> ().StartChronometer ();
	}

	public void Restart()
	{
		SceneManager.LoadScene ("MainGame");
		Time.timeScale = 1f;
	}

	public void Menu()
	{
		SceneManager.LoadScene ("MainMenu");
		Time.timeScale = 1f;
	}
	
	public void ContinueLevelCompleteUI()
	{
		//analoga survivval or story na bgazei kai scene
		SceneManager.LoadScene ("GameModeSelection");
		Time.timeScale = 1f;
	}

	public void StatisticsButton()
	{
		if (levelCompleteUI.activeSelf) {
			levelCompleteUI.SetActive (false);
			oldScene = 0;
		} else if (gameOverUI.activeSelf) {
			gameOverUI.SetActive (false);
			oldScene = 1;
		}
		StatisticsUI.SetActive (true);
		GetComponent<StatisticsMenuController> ().enabled = true;
	}

	public void Return()
	{
		GetComponent<StatisticsMenuController> ().enabled = false;
		StatisticsUI.SetActive (false);
		if (oldScene == 0)
			levelCompleteUI.SetActive (true);
		else
			gameOverUI.SetActive (true);
	}

	//GETTERS
	public int NumbersOfEnemies{
		get{ return numberOFEnemies;}
		set{ numberOFEnemies = value;}
	}
}

