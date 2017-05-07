using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveControler : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();
	private Transform spawnPoint;
	private List<List<string>> waves = new List<List<string>>();
	private GameObject gameFlow;

	private float timeBetweenEnemies;
	private float countdown;
	private int countEnemy; 
	private int waveIndex = 0;
	private int enemyIndex;
	private float oldTiBeEn = 0;
	private bool endOfWaves = false;
	private bool outWave = true;
	
	private List<GameObject> startTiles;


	void Start()
	{
		startTiles = GetComponent<GridController> ().GetStartTiles();
		waves = LevelHandler.GetSelectedWave ();
		gameFlow = GameObject.Find("GameFlow");
	}

	public void callWave()
	{
		if (outWave) {
			GameObject.Find("WaveText").GetComponent<WaveTextController>().updateText(waveIndex+1);
			StartCoroutine (next_Wave ());
		}
	}

	IEnumerator next_Wave()
	{
		outWave = false;
		if (waveIndex < waves.Count) {
			List<string> wave = waves [waveIndex];
			string item = "", values = "";
			int index, oldindex;
			for (int i = 0; i < wave.Count; i++) {	
				oldindex = 0;
				item = wave [i];
				item.Replace (" ", "");
				index = item.IndexOf ('-');
				values = item.Substring (oldindex, (index - oldindex));
				countdown = float.Parse (values);
				oldindex = index;

				index = item.IndexOf ('-', (index + 1));
				values = item.Substring ((oldindex + 1), (index - oldindex - 1));
				countEnemy = int.Parse (values);
				oldindex = index;

				index = item.IndexOf ('-', (index + 1));
				values = item.Substring ((oldindex + 1), (index - oldindex - 1));
				enemyIndex = int.Parse (values);

				values = item.Substring ((index + 1), (item.Length - index - 1));
				timeBetweenEnemies = float.Parse (values);

				yield return new WaitForSeconds (countdown - oldTiBeEn);
				for (int j = 0; j < countEnemy; j++) {
					int startTileIndex = Random.Range(0,startTiles.Count);
					spawnPoint = startTiles [startTileIndex].GetComponent<PathTile> ().transform;
					GameObject enem = Instantiate (enemies [enemyIndex], spawnPoint.position, spawnPoint.rotation) as GameObject;
					enem.tag = "Enemy";
					enem.GetComponent<MainEnemy>().Initialize(startTileIndex);
					gameFlow.GetComponent<FlowController> ().NumbersOfEnemies++;
					yield return new WaitForSeconds (timeBetweenEnemies);
				}
				oldTiBeEn = timeBetweenEnemies;
			}
			waveIndex++;
			if (waveIndex >= waves.Count) {
				endOfWaves = true;
			}
		}
		GameObject.Find("Start_and_Speed_Button").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/startlevel",typeof(Sprite));
		outWave = true;
	}

	public bool EndOfWaves
	{
		get{ return endOfWaves; }
		set{ endOfWaves = value; }
	}

	//xtypouse error me ton allo tropo, :(
	public bool getOutWave(){
		return outWave;
	}

	public int getWaveIndex(){
		return waveIndex;
	}
}