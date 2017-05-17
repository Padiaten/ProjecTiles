using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();

	private float countdown,oldTiBeEn = 0;
	private List<List<string>> waves = new List<List<string>> ();
	private bool endWave = false;

	protected float timeBetweenEnemies;
	protected int enemiesNumber;
	protected int enemyIndex,waveIndex;
	protected bool outWave = true;
	protected GameObject gameFlow;
	protected int starTileIndex;
	protected Transform spawnPoint;

	public void Init(int i)
	{
		enemyIndex = 0;
		waveIndex = 0;
		outWave = true;
		gameFlow = GameObject.Find("GameFlow");
		starTileIndex = i;
		spawnPoint = gameFlow.GetComponent<GridController> ().GetStartTiles()[starTileIndex].GetComponent<PathTile>().transform;
	}

	public void Initialize(int i)
	{
		Init (i);
		waves = LevelHandler.GetSelectedWave ()[starTileIndex];
	}

	public void next_Wave(){
		StartCoroutine (WaveSpawner());
	}

	IEnumerator WaveSpawner()
	{
		outWave = false;
		if (waveIndex < waves.Count) {
			List<string> wave = waves [waveIndex];
			for (int i = 0; i < wave.Count; i++) {	
				ReadList (i,wave);

				yield return new WaitForSeconds (countdown - oldTiBeEn);
				for (int j = 0; j < enemiesNumber; j++) {
					CreateEnemy (enemyIndex);
					yield return new WaitForSeconds (timeBetweenEnemies);
				}
				oldTiBeEn = timeBetweenEnemies;
			}
			waveIndex++;
			if (waveIndex >= waves.Count) {
				endWave = true;
			}
		}
		outWave = true;
	}

	public void ReadList(int i,List<string> wave)
	{
		int index, oldindex;
		string item = "", values = "";

		oldindex = 0;
		item = wave [i].Replace(" ","");
		index = item.IndexOf ('-');
		values = item.Substring (oldindex, (index - oldindex));
		countdown = float.Parse (values);
		oldindex = index;

		index = item.IndexOf ('-', (index + 1));
		values = item.Substring ((oldindex + 1), (index - oldindex - 1));
		enemiesNumber = int.Parse (values);
		oldindex = index;

		index = item.IndexOf ('-', (index + 1));
		values = item.Substring ((oldindex + 1), (index - oldindex - 1));
		enemyIndex = int.Parse (values);

		values = item.Substring ((index + 1), (item.Length - index - 1));
		timeBetweenEnemies = float.Parse (values);
	}

	public void CreateEnemy(int index)
	{
		GameObject enem = Instantiate (enemies [index], spawnPoint.position, spawnPoint.rotation);
		enem.tag = "Enemy";
		enem.name = "Enemy"+(index+1);
		enem.GetComponent<Enemy> ().Initialize (starTileIndex);
		gameFlow.GetComponent<FlowController> ().NumbersOfEnemies++;
	}

	public bool OutWave
	{
		get{ return outWave; }
		set{ outWave = value; }
	}

	public List<GameObject> EnemiesList
	{
		get{ return enemies; }
	}

	public bool EndWave{
		get{ return endWave; }
		set{ endWave = value; }
	}
}
